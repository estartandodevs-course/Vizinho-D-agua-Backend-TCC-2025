using System.ComponentModel.DataAnnotations;

namespace VizinhoDAgua.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }   
}