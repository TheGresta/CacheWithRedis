namespace Persistence.Entities;

public class City
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public virtual Country? Country { get; set; }

    public City()
    {
    }

    public City(int cityId, string name, int countryId) : this()
    {
        CityId = cityId;
        Name = name;
        CountryId = countryId;
    }
}
