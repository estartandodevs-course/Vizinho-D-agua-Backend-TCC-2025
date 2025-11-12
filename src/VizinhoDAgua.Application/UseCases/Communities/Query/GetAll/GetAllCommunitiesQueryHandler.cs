using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Communities.Query.GetAll
{
    public class GetAllCommunitiesQueryHandler : IRequestHandler<GetAllCommunitiesQuery, CommandResponse<GetAllCommunitiesQueryResponse>>
    {
        private readonly ICommunityRepository _communityRepository;

        public GetAllCommunitiesQueryHandler(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<GetAllCommunitiesQueryResponse>> Handle(GetAllCommunitiesQuery request, CancellationToken cancellationToken)
        {
            var communities = await _communityRepository.GetAllAsync();

            return CommandResponse<GetAllCommunitiesQueryResponse>.Success(new GetAllCommunitiesQueryResponse(communities), HttpStatusCode.OK);
        }
    }
}
