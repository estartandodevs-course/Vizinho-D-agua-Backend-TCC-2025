using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetById
{
    public class GetCommunityByIdQueryHandler : GetByIdQueryHandler<CommunityEntity, GetCommunityByIdQuery, GetCommunityByIdQueryResponse>
    {
        public GetCommunityByIdQueryHandler(ICommunityRepository communityRepository, IMapper mapper) : base(communityRepository, mapper)
        {
        }
    }
}
