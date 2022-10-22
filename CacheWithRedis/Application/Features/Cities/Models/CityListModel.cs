using Application.Features.Cities.Dtos;
using Core.Paging;

namespace Application.Features.Cities.Models;

public class CityListModel : BasePageableModel
{
    public IList<CityDto> Items { get; set; }
}
