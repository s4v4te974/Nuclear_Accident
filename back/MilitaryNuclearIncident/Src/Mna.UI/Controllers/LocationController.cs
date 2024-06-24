using Microsoft.AspNetCore.Mvc;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;
using System.Net.Mime;

namespace MilitaryNuclearAccident.Src.Mna.UI.Controllers
{

    [Route(ConstUtils.LOCATION_ROOT_URL)]
    [ApiController]
    public class LocationController(ILocationService coordonateService) : ControllerBase
    {

        private readonly ILocationService _coordonateService = coordonateService;

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetAllCoordonates()
        {
            IEnumerable<LocationResponse> coordonatesResponse = await _coordonateService.GetLocationAsync();
            return coordonatesResponse == null || !coordonatesResponse.Any() ? NotFound() : Ok(coordonatesResponse);
        }

        [HttpPost(ConstUtils.LOCATION_SPECIFIC_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<LocationResponse>> GetSpecificLocation([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                LocationResponse? coordonateResponse = await _coordonateService.GetSingleLocationAsync(id);
                return coordonateResponse == null ? NotFound() : Ok(coordonateResponse);
            }
        }


        [HttpPost("{location}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetBrokenArrowsByLocationAsync([FromRoute] string location)
        {
            if (!System.Enum.TryParse(location, true, out AvailableLocation locationEnum))
            {
                return BadRequest("Invalid location");
            }
            IEnumerable<LocationResponse?> brokenArrows = await _coordonateService.GetBrokenArrowsByLocationAsync(locationEnum);
            return brokenArrows == null || !brokenArrows.Any() ? NotFound() : Ok(brokenArrows);
        }
    }
}
