using Application.Features.Countries.Queries.GetListCountry;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] GetListCountryQuery getListCountryQuery)
        {
            var response = await Mediator.Send(getListCountryQuery);
            return Ok(response);
        }
    }
}
