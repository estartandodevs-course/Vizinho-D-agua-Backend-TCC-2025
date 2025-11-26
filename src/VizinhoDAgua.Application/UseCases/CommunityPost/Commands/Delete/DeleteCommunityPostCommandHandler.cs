using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Delete
{
    public class DeleteCommunityPostCommandHandler : DeleteCommandHandler<CommunityPostEntity, DeleteCommunityPostCommand>
    {
        public DeleteCommunityPostCommandHandler(ICommunityPostRepository communityPostRepository) : base(communityPostRepository)
        {
        }
    }
}
