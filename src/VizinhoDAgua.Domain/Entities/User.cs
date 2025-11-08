using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
        
        public bool IsAdmin { get; set; } = false;
        public string? ProfileImage { get; set; }

        // Many-to-Many
        public List<Community> Communities { get; set; } = new List<Community>();

        // One-to-Many: posts do usuário
        public List<CommunityPost> Posts { get; set; } = new List<CommunityPost>();

        // One-to-Many: reports do usuário
        public List<Report> Reports { get; set; } = new List<Report>();
    }
}