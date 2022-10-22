namespace Application.Features.Cities.Dtos;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public DateTime LastUpdate { get; set; }
}
