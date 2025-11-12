using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Communities.Query.GetAll
{
    public class GetAllCommunitiesQueryResponse
    {
        public IList<Community> Communities { get; set; }

        public GetAllCommunitiesQueryResponse(IList<Community> communities)
        {
            Communities = communities;
        }
    }
}
