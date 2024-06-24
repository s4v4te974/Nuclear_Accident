﻿using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers
{
    [Route(ConstUtils.VEHICULE_ROOT_URL)]
    [ApiController]
    public class VehiculeController(IVehiculeService vehiculeService) : ControllerBase
    {

        private readonly IVehiculeService _vehiculeService = vehiculeService;

        [HttpGet()]
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
        public async Task<ActionResult<VehiculeResponse>> GetBrokenArrowsByVehiculeAsync([FromRoute] string vehicule)
        {
            if (!System.Enum.TryParse(vehicule, true, out AvailableVehicule vehiculeEnum))
            {
                return BadRequest("Invalid vehicule");
            }
            IEnumerable<VehiculeResponse?> brokenArrows = await _vehiculeService.GetBrokenArrowsByVehiculeAsync(vehiculeEnum);
            return brokenArrows == null || !brokenArrows.Any() ? NotFound() : Ok(brokenArrows);
        }
    }
}
