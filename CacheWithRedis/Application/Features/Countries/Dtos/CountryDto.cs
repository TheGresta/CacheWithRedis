namespace Application.Features.Countries.Dtos;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LasUpdate { get; set; }
    public virtual ICollection<CountryCityDto>? Cities { get; set; }
}
