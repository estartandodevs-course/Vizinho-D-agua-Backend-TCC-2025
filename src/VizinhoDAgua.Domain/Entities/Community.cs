using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public class Community : Entity
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? CoverImage { get; set; }

        // Many-to-Many
        public List<User> Followers { get; set; } = new List<User>();
        
        // One-to-Many: posts da comunidade
        public List<CommunityPost> Posts { get; set; } = new List<CommunityPost>();
    }
}