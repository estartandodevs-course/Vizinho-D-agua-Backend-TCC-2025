using AutoMapper;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Application.UseCases.Community.Command.Update;
using VizinhoDAgua.Application.UseCases.CommunityPost.Command.Create;
using VizinhoDAgua.Application.UseCases.CommunityPost.Command.Update;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
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

            CreateMap<CreateCommunityPostRequest, CreateCommunityPostCommand>();
            CreateMap<CreateCommunityPostCommand, CommunityPostEntity>();
            CreateMap<(Guid Id, UpdateCommunityPostRequest Request), UpdateCommunityPostCommand>()
                .ConstructUsing(source => new UpdateCommunityPostCommand(
                    source.Id,
                    source.Request.Content,
                    source.Request.Images
                ));
            CreateMap<UpdateCommunityPostCommand, CommunityPostEntity>()
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
        }
    }
}
