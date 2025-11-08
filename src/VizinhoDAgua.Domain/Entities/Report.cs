using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public class Report : Entity
    {
        [Required]
        public Guid ReporterId { get; set; }
        public User Reporter { get; set; } = null!;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public string ReportType { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public List<string>? Attachments { get; set; }
    }
}