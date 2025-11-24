using VizinhoDAgua.Domain.Entities.Abstractions;

namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityEntity : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Guid? CreatedById { get; private set; }
        public UserEntity? CreatedBy { get; private set; }
        public string? CoverImage { get; private set; }

        // Many-to-Many
        public List<UserEntity> Followers { get; private set; } = [];

        // One-to-Many: posts da comunidade
        public List<CommunityPostEntity> Posts { get; private set; } = [];

        public CommunityEntity() { }  // EF Core

        public CommunityEntity(string title, string description, Guid? createdById ,string? coverImage)
        {
            Title = title;
            Description = description;
            CoverImage = coverImage;
            CreatedById = createdById;
        }
    }
}