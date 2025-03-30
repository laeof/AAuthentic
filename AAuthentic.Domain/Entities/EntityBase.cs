namespace AAuthentic.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; init; }
    public string CreatedDateUnix { get; set; } = string.Empty;
    public string UpdatedDateUnix { get; set; } = string.Empty;
    public EntityBase()
    {
        Id = Guid.NewGuid();
    }
}
