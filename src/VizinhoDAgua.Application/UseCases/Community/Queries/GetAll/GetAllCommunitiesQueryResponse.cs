using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetAll
{
    public class GetAllCommunitiesQueryResponse
    {
        public IList<CommunityEntity> Communities { get; }

        public GetAllCommunitiesQueryResponse(IList<CommunityEntity> communities)
        {
            Communities = communities;
        }
    }
}
