using AutoMapper;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Application.UseCases.Community.Command.Update;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Application.UseCases.User.Commands.Update;
using VizinhoDAgua.Domain.Entities;

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
                .ForAllMembers(opts 
                    => opts.Condition((_, _, srcMember) => srcMember != null));


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
                .ForAllMembers(opts 
                    => opts.Condition((_, _, srcMember) => srcMember != null));
        
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
                .ForAllMembers(opts 
                    => opts.Condition((_, _, srcMember) => srcMember != null));
        }
    }
}
