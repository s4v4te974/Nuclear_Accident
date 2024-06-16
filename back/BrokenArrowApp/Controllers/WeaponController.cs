
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Service;
using BrokenArrowApp.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BrokenArrowApp.Controllers
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class WeaponController(IWeaponService weaponService) : ControllerBase
    {

        private readonly IWeaponService _weaponService = weaponService;


        [HttpGet(ConstUtils.ALL_WEAPON_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetAllWeapons()
        {
            IEnumerable<WeaponResponse> weaponsResponse = await _weaponService.GetAllWeaponAsync();
            return weaponsResponse == null || !weaponsResponse.Any() ? NotFound() : Ok(weaponsResponse);
        }

        [HttpPost(ConstUtils.SPECIFIC_WEAPON + "{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<WeaponResponse>> GetSpecificWeapon(Guid id)
        {
            WeaponResponse? weaponResponse = await _weaponService.GetSpecificWeaponAsync(id);
            return weaponResponse == null ? NotFound() : Ok(weaponResponse);
        }
    }
}
