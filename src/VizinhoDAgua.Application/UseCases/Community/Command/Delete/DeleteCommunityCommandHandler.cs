using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Command.Delete
{
    public class DeleteCommunityCommandHandler : DeleteCommandHandler<CommunityEntity, DeleteCommunityCommand>
    {
        public DeleteCommunityCommandHandler(ICommunityRepository communityRepository) : base(communityRepository)
        {
        }
    }
}
