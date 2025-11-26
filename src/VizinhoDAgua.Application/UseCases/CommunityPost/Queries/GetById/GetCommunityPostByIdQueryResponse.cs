using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetById
{
    public class GetCommunityPostByIdQueryResponse
    {
        public CommunityPostEntity CommunityPost { get; }

        public GetCommunityPostByIdQueryResponse(CommunityPostEntity communityPost)
        {
            CommunityPost = communityPost;
        }
    }
}
