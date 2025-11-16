using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Community.Query.GetAll
{
    public class GetAllCommunitiesQueryResponse
    {
        public IList<CommunityEntity> Communities { get; set; }

        public GetAllCommunitiesQueryResponse(IList<CommunityEntity> communities)
        {
            Communities = communities;
        }
    }
}
