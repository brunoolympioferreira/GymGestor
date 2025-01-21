namespace GymGestor.Core.Entities;
public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }
}
