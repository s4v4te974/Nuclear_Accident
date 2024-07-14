using Microsoft.AspNetCore.Mvc;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Services.Interfaces.Common;
using System.Net.Mime;

namespace NuclearIncident.Src.UI.Controllers
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
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetBrokenArrowssByLocationAsync([FromRoute] string location)
        {
            if (!Enum.TryParse(location, true, out AvailableLocation locationEnum))
            {
                return BadRequest("Invalid location");
            }
            IEnumerable<LocationResponse?> BrokenArrowss = await _coordonateService.GetBrokenArrowssByLocationAsync(locationEnum);
            return BrokenArrowss == null || !BrokenArrowss.Any() ? NotFound() : Ok(BrokenArrowss);
        }
    }
}
