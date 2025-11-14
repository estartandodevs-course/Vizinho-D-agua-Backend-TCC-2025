namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityPost : Entity
    {
        public string Content { get; private set; } = string.Empty;
        public List<string> Images { get; private set; } = [];

        public Guid AuthorId { get; private set; }
        public User? Author { get; private set; }

        public Guid CommunityId { get; private set; }
        public Community? Community { get; private set; }

        public CommunityPost() { } // EF Core

        public CommunityPost(Guid authorId, Guid communityId, string content, List<string>? images)
        {
            AuthorId = authorId;
            CommunityId = communityId;
            Content = content;
            Images = images ?? [];
        }

    }
}