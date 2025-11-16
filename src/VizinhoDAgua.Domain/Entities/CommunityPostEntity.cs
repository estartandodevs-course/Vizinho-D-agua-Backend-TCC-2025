namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityPostEntity : Entity
    {
        public string Content { get; private set; } = string.Empty;
        public List<string> Images { get; private set; } = [];

        public Guid AuthorId { get; private set; }
        public UserEntity? Author { get; private set; }

        public Guid CommunityId { get; private set; }
        public CommunityEntity? Community { get; private set; }

        public CommunityPostEntity() { } // EF Core

        public CommunityPostEntity(Guid authorId, Guid communityId, string content, List<string>? images)
        {
            AuthorId = authorId;
            CommunityId = communityId;
            Content = content;
            Images = images ?? [];
        }

        public void Update(string? content, List<string>? images)
        {
            Content = content ?? Content;
            Images = images ?? Images;
        }
    }
}