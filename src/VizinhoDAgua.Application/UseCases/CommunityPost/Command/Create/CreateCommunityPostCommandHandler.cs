using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Command.Create
{
    public class CreateCommunityPostCommandHandler
        : CreateCommandHandler<CommunityPostEntity, CreateCommunityPostCommand, CreateCommunityPostCommandResponse>
    {
        public CreateCommunityPostCommandHandler(ICommunityPostRepository communityPostRepository, IMapper mapper) : base(communityPostRepository, mapper)
        {
        }
    }
}