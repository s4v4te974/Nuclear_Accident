using Microsoft.AspNetCore.Mvc;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;

namespace MilitaryNuclearAccident.Src.Mna.UI.Controllers
{
    [Route(ConstUtils.LOCATION_ROOT_URL)]
    [ApiController]
    public class StatsController(IStatistiqueService service) : ControllerBase
    {
        private readonly IStatistiqueService _statistiquesService = service;

        [HttpGet(ConstUtils.STATS_URL)]
        public async Task<ActionResult<StatsResponse>> GetBrokenArrows()
        {
            StatsResponse brokenArrows = await _statistiquesService.GetAllStatsAsync();
            return brokenArrows == null ? NotFound() : Ok(brokenArrows);
        }
    }
}
