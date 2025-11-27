using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Commands.Create
{
    public class CreateCommunityCommandHandler
        : CreateCommandHandler<CommunityEntity, CreateCommunityCommand, CreateCommunityCommandResponse>
    {
        public CreateCommunityCommandHandler(ICommunityRepository communityRepository, IMapper mapper) : base(communityRepository, mapper)
        {
        }
    }
}