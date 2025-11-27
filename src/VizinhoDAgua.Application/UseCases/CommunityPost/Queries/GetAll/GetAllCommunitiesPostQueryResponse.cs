using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetAll
{
    public class GetAllCommunitiesPostQueryResponse
    {
        public IList<CommunityPostEntity> CommunitiesPost { get; }

        public GetAllCommunitiesPostQueryResponse(IList<CommunityPostEntity> communitiesPost)
        {
            CommunitiesPost = communitiesPost;
        }
    }
}
