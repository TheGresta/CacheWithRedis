using Core.Entity;

namespace Persistence.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<City>? Cities { get; set; }

    public Country()
    {
    }

    public Country(string name) : this()
    {
        Name = name;
    }
}

