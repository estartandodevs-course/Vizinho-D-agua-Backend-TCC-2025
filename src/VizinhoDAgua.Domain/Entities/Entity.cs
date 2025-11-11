using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizinhoDAgua.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // configurar no banco via migrations (evitar nulo)
        public DateTime? UpdatedAt { get; set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }   
}
