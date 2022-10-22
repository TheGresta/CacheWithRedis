using Core.Entity;

namespace Persistence.Entities;

public class Country : BaseEntity
{
    public int CountryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<City>? Cities { get; set; }

    public Country()
    {
    }

    public Country(int countryId, string name) : this()
    {
        CountryId = countryId;
        Name = name;
    }
}

