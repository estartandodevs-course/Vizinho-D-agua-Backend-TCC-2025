using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Community.Queries.GetById
{
    public class GetCommunityByIdQueryResponse
    {
        public CommunityEntity Community { get; }

        public GetCommunityByIdQueryResponse(CommunityEntity community)
        {
            Community = community;
        }
    }
}
