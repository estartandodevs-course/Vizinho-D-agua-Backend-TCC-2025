using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Update
{
    public class UpdateCommunityCommandHandler
        : UpdateCommandHandler<CommunityEntity, UpdateCommunityCommand>
    {
        public UpdateCommunityCommandHandler(ICommunityRepository communityRepository, IMapper mapper) : base(communityRepository, mapper)
        {
        }
    }
}
