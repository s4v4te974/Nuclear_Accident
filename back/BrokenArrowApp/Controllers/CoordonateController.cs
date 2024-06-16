using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Service;
using BrokenArrowApp.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BrokenArrowApp.Controllers
{

    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class CoordonateController(ICoordonateService coordonateService) : ControllerBase
    {

        private readonly ICoordonateService _coordonateService = coordonateService;

        [HttpGet(ConstUtils.ALL_COORDONATE_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<CoordonateResponse>>> GetAllCoordonates()
        {
            IEnumerable<CoordonateResponse> coordonatesResponse = await _coordonateService.GetAllCoordonatesAsync();
            return coordonatesResponse == null || !coordonatesResponse.Any() ? NotFound() : Ok(coordonatesResponse);
        }

        [HttpPost(ConstUtils.SPECIFIC_COORDONATE + "{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CoordonateResponse>> GetSpecificCoordonate(Guid id)
        {
            CoordonateResponse? coordonateResponse = await _coordonateService.GetSpecificCoordonateAsync(id);
            return coordonateResponse == null ? NotFound() : Ok(coordonateResponse);
        }
    }
}
