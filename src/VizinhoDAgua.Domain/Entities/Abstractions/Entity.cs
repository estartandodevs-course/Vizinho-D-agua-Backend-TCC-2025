namespace VizinhoDAgua.Domain.Entities.Abstractions
{

    public abstract class Entity : AuditableEntity
    {
        public Guid Id { get; set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }   
}