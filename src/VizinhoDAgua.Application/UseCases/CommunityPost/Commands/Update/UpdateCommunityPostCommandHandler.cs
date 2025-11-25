using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Command.Update
{
    public class UpdateCommunityPostCommandHandler
        : UpdateCommandHandler<CommunityPostEntity, UpdateCommunityPostCommand>
    {
        public UpdateCommunityPostCommandHandler(ICommunityPostRepository communityPostRepository, IMapper mapper) : base(communityPostRepository, mapper)
        {
        }
    }
}
