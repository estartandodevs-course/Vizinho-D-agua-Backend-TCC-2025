
namespace VizinhoDAgua.Domain.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public abstract class Entity : IAuditable
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }   
}
