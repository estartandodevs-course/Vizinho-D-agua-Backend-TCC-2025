using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public class EducationContent : Entity
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}