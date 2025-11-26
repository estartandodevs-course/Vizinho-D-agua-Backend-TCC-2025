using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using AutoMapper;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetAll
{
    public class GetAllCommunitiesPostQueryHandler : GetAllQueryHandler<CommunityPostEntity, GetAllCommunitiesPostQuery, GetAllCommunitiesPostQueryResponse>
    {
        public GetAllCommunitiesPostQueryHandler(ICommunityPostRepository communityPostRepository, IMapper mapper) : base(communityPostRepository, mapper)
        {
        }
    }
}
