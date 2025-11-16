namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityEntity : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string? CoverImage { get; private set; }

        // Many-to-Many
        public List<UserEntity> Followers { get; private set; } = [];

        // One-to-Many: posts da comunidade
        public List<CommunityPostEntity> Posts { get; private set; } = [];

        public CommunityEntity() { }  // EF Core

        public CommunityEntity(string title, string description, string? coverImage)
        {
            Title = title;
            Description = description;
            CoverImage = coverImage;
        }

        public void Update(string? title, string? description, string? coverImage)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            CoverImage = coverImage ?? CoverImage;
        }
    }
}