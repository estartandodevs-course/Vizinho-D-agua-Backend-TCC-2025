using AutoMapper;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Alert.Commands.Create;
using VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus;
using VizinhoDAgua.Application.UseCases.Community.Commands.Create;
using VizinhoDAgua.Application.UseCases.Community.Commands.Update;
using VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Create;
using VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Update;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update;
using VizinhoDAgua.Application.UseCases.Report.Commands.Create;
using VizinhoDAgua.Application.UseCases.Report.Commands.Update;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Application.UseCases.User.Commands.Update;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // COMMUNITY
            CreateMap<CreateCommunityRequest, CreateCommunityCommand>();
            CreateMap<CreateCommunityCommand, CommunityEntity>();
            CreateMap<(Guid Id, UpdateCommunityRequest Request), UpdateCommunityCommand>()
                .ConstructUsing(source => new UpdateCommunityCommand(
                    source.Id,
                    source.Request.Title,
                    source.Request.Description,
                    source.Request.CoverImage
                ));
            CreateMap<UpdateCommunityCommand, CommunityEntity>()
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));


            // EDUCATIONAL CONTENT
            // Request ~> Command
            CreateMap<CreateEducationalContentRequest, CreateEducationContentCommand>();
            // Command ~> Entity
            CreateMap<CreateEducationContentCommand, EducationContentEntity>();
            // Update
            CreateMap<(Guid Id, UpdateEducationalContentRequest Request), UpdateEducationContentCommand>()
                .ConstructUsing(source => new UpdateEducationContentCommand(
                    source.Id,
                    source.Request.Title,
                    source.Request.Image,
                    source.Request.Author,
                    source.Request.FilePath
                ));
            CreateMap<UpdateEducationContentCommand, EducationContentEntity>()
                // evita sobrescrever propriedades quando o campo vem null
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));


            // USER
            // Request ~> Command
            CreateMap<CreateUserRequest, CreateUserCommand>()
                .ConstructUsing(source => new CreateUserCommand());
            // Command ~> Entity
            CreateMap<CreateUserCommand, UserEntity>();
            // Update
            CreateMap<(Guid Id, UpdateUserRequest Request), UpdateUserCommand>()
                .ConstructUsing(source => new UpdateUserCommand(
                    source.Id,
                    source.Request.Name,
                    source.Request.Email,
                    source.Request.Password,
                    source.Request.ProfileImage
                ));
            CreateMap<UpdateUserCommand, UserEntity>()
                // evita sobrescrever propriedades quando o campo vem null
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));


            // COMMUNITY POST
            CreateMap<CreateCommunityPostRequest, CreateCommunityPostCommand>();
            CreateMap<CreateCommunityPostCommand, CommunityPostEntity>();
            CreateMap<(Guid Id, UpdateCommunityPostRequest Request), UpdateCommunityPostCommand>()
                .ConstructUsing(source => new UpdateCommunityPostCommand(
                    source.Id,
                    source.Request.Content,
                    source.Request.Images
                ));
            CreateMap<UpdateCommunityPostCommand, CommunityPostEntity>()
                .ForMember(
                    dest => dest.Images,
                    opt => opt.Condition(src => src.Images != null && src.Images.Count > 0)
                )
                .ForAllMembers(opts =>
                    {
                        if (opts.DestinationMember.Name == nameof(CommunityPostEntity.Images)) return;
                        opts.Condition((_, _, srcMember) => srcMember != null);
                    }
                );


            // REPORT
            CreateMap<CreateReportRequest, CreateReportCommand>();
            CreateMap<CreateReportCommand, ReportEntity>()
                .ForMember(dest => dest.ReportType, opt => 
                    opt.MapFrom(src => Enum.Parse<ReportType>(src.ReportType, true)))
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<(Guid Id, UpdateReportRequest Request), UpdateReportCommand>()
                .ConstructUsing(source => new UpdateReportCommand(
                    source.Id,
                    source.Request.Description,
                    source.Request.ReportType,
                    source.Request.ReporterId,
                    source.Request.PostalCode,
                    source.Request.StateCode,
                    source.Request.City,
                    source.Request.Neighborhood,
                    source.Request.Road,
                    source.Request.Lat,
                    source.Request.Lon
                ));
            CreateMap<UpdateReportCommand, ReportEntity>()
                .ForMember(dest => dest.ReportType, opt =>
                    opt.MapFrom(src => Enum.Parse<ReportType>(src.ReportType, true)))
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));


            // ALERT
            // Request ~> Command
            CreateMap<CreateAlertRequest, CreateAlertCommand>();
            // Command ~> Entity
            CreateMap<CreateAlertCommand, AlertEntity>();
            // Update
            CreateMap<(Guid Id, UpdateAlertStatusRequest Request), UpdateAlertStatusCommand>()
                .ConstructUsing(src => new UpdateAlertStatusCommand(
                    src.Id,
                    (AlertStatus)src.Request.Status
                ));
        }
    }
}
