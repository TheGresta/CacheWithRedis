namespace Core.Entity;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime LastUpdate { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(int id)
    {
        Id = id;
    }
}
