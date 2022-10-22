using Application.Features.Countries.Dtos;
using Core.Paging;

namespace Application.Features.Countries.Models;

public class CountryListModel : BasePageableModel
{
    public IList<CountryDto> Items { get; set; }
}
