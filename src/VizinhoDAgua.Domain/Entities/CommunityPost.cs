namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityPost : Entity
    {
        public Guid AuthorId { get; private set; }
        public User? Author { get; private set; }
        
        public Guid CommunityId { get; private set; }
        public Community? Community { get; private set; }
        
        public string? Content { get; private set; }
        public List<string> Images { get; private set; } = [];
        
        public CommunityPost() { } // EF Core

        public CommunityPost(Guid authorId, Guid communityId, string? content,  List<string>? images = null)
        {
            AuthorId = authorId;
            CommunityId = communityId;
            Content = content;
            if (images != null) Images = images;
        }
    }
}
