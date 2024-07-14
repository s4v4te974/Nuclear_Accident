using Microsoft.AspNetCore.Mvc;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Services.Interfaces.Common;
using System.Net.Mime;

namespace NuclearAccident.Src.UI.Controllers
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
            IEnumerable<WeaponResponse> weaponsResponse = await _weaponService.GetWeaponsAsync();
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
        public async Task<ActionResult<WeaponResponse>> GetAccidentsByWeaponAsync([FromRoute] string weapon)
        {
            if (!Enum.TryParse(weapon, true, out AvailableWeapon weaponEnum))
            {
                return BadRequest("Invalid weapon");
            }
            IEnumerable<WeaponResponse?> Accidents = await _weaponService.GetAccidentsByWeaponAsync(weaponEnum);
            return Accidents == null || !Accidents.Any() ? NotFound() : Ok(Accidents);
        }
    }
}

