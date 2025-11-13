namespace VizinhoDAgua.Application.UseCases.Community.Query.GetAll
{
    public class GetAllCommunitiesQueryResponse
    {
        public IList<Domain.Entities.Community> Communities { get; set; }

        public GetAllCommunitiesQueryResponse(IList<Domain.Entities.Community> communities)
        {
            Communities = communities;
        }
    }
}
