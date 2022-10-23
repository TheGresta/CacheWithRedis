using Application.Features.Cities.Commands.DeleteCity;
using Application.Features.Cities.Queries.GetByIdCity;
using Application.Features.Cities.Queries.GetListCity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery]GetByIdCityQuery getByIdCityQuery)
        {
            var response = await Mediator.Send(getByIdCityQuery);
            return Ok(response);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] GetListCityQuery getListCityQuery)
        {
            var response = await Mediator.Send(getListCityQuery);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCityCommand deleteCityCommand)
        {
            var response = await Mediator.Send(deleteCityCommand);
            return Ok(response);
        }
    }
}
