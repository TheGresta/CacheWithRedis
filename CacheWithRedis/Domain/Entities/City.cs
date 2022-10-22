using Core.Entity;

namespace Persistence.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public virtual Country? Country { get; set; }

    public City()
    {
    }

    public City(string name, int countryId) : this()
    {
        Name = name;
        CountryId = countryId;
    }
}
