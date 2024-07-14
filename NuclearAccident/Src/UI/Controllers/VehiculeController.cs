using Microsoft.AspNetCore.Mvc;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Services.Interfaces.Common;
using System.Net.Mime;

namespace NuclearIncident.Src.UI.Controllers
{
    [Route(ConstUtils.VEHICULE_ROOT_URL)]
    [ApiController]
    public class VehiculeController(IVehiculeService vehiculeService) : ControllerBase
    {

        private readonly IVehiculeService _vehiculeService = vehiculeService;

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<VehiculeResponse>>> GetAllVehicules()
        {
            IEnumerable<VehiculeResponse> vehiculesResponse = await _vehiculeService.GetVehiculesAsync();
            return vehiculesResponse == null || !vehiculesResponse.Any() ? NotFound() : Ok(vehiculesResponse);
        }

        [HttpPost(ConstUtils.VEHICULE_SPECIFIC_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<VehiculeResponse>> GetSpecificVehicule([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                VehiculeResponse? vehiculeResponse = await _vehiculeService.GetSingleVehiculeAsync(id);
                return vehiculeResponse == null ? NotFound() : Ok(vehiculeResponse);
            }
        }

        [HttpPost("{vehicule}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<VehiculeResponse>> GetAccidentsByVehiculeAsync([FromRoute] string vehicule)
        {
            if (!Enum.TryParse(vehicule, true, out AvailableVehicule vehiculeEnum))
            {
                return BadRequest("Invalid vehicule");
            }
            IEnumerable<VehiculeResponse?> Accidents = await _vehiculeService.GetAccidentsByVehiculeAsync(vehiculeEnum);
            return Accidents == null || !Accidents.Any() ? NotFound() : Ok(Accidents);
        }
    }
}
