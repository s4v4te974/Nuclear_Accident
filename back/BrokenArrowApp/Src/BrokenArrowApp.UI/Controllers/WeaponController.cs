using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers
{
    [Route(ConstUtils.WEAPON_ROOT_URL)]
    [ApiController]
    public class WeaponController(IWeaponService weaponService) : ControllerBase
    {

        private readonly IWeaponService _weaponService = weaponService;


        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetAllWeapons()
        {
            IEnumerable<WeaponResponse> weaponsResponse = await _weaponService.GetWeaponAsync();
            return weaponsResponse == null || !weaponsResponse.Any() ? NotFound() : Ok(weaponsResponse);
        }

        [HttpPost(ConstUtils.WEAPON_SPECIFIC_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<WeaponResponse>> GetSpecificWeapon([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                WeaponResponse? weaponResponse = await _weaponService.GetSingleWeaponAsync(id);
                return weaponResponse == null ? NotFound() : Ok(weaponResponse);
            }
        }

        [HttpPost("{weapon}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<WeaponResponse>> GetBrokenArrowsByWeaponAsync([FromRoute] string weapon)
        {
            if (!System.Enum.TryParse(weapon, true, out AvailableWeapon weaponEnum))
            {
                return BadRequest("Invalid weapon");
            }
            IEnumerable<WeaponResponse?> brokenArrows = await _weaponService.GetBrokenArrowsByWeaponAsync(weaponEnum);
            return brokenArrows == null || !brokenArrows.Any() ? NotFound() : Ok(brokenArrows);
        }
    }
}

