using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using AutoMapper;

namespace VizinhoDAgua.Application.UseCases.Community.Query.GetAll
{
    public class GetAllCommunitiesQueryHandler : GetAllQueryHandler<CommunityEntity, GetAllCommunitiesQuery, GetAllCommunitiesQueryResponse>
    {
        public GetAllCommunitiesQueryHandler(ICommunityRepository communityRepository, IMapper mapper) : base(communityRepository, mapper)
        {
        }
    }
}
