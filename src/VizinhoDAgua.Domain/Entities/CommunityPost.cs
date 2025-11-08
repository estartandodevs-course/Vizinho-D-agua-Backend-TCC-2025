using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public class CommunityPost : Entity
    {
        [Required]
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;

        [Required]
        public Guid CommunityId { get; set; }
        public Community Community { get; set; } = null!;

        [Required]
        public string Content { get; set; } = string.Empty;
        public List<string> Images { get; set; } = [];
    }
}