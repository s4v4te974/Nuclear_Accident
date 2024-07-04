using Microsoft.AspNetCore.Mvc;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Services.Interfaces;
using System.Net.Mime;

namespace NuclearAccident.Src.Mna.UI.Controllers
{
    [Route(ConstUtils.LOCATION_ROOT_URL)]
    [ApiController]
    public class StatsController(IStatistiqueService service) : ControllerBase
    {
        private readonly IStatistiqueService _statistiquesService = service;

        [HttpGet(ConstUtils.STATS_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<StatsResponse>> GetBrokenArrows()
        {
            StatsResponse stats = await _statistiquesService.GetAllStatsAsync();
            return stats == null ? NotFound() : Ok(stats);
        }
    }
}
