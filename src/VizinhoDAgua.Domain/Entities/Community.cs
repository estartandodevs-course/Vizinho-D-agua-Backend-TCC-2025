namespace VizinhoDAgua.Domain.Entities
{
    public class Community : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string? CoverImage { get; private set; }

        // Many-to-Many
        public List<User> Followers { get; private set; } = [];
        
        // One-to-Many: posts da comunidade
        public List<CommunityPost> Posts { get; private set; } = [];

        public Community(string title, string description, string? coverImage)
        {
            Title = title;
            Description = description;
            CoverImage = coverImage;
        }
    }
}