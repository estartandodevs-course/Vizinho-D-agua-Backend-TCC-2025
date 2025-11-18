using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Community.Query.GetById
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
