using Microsoft.AspNetCore.Mvc;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Services.Interfaces.BrokenArrows;
using System.Net.Mime;

namespace NuclearAccident.Src.UI.Controllers.BrokenArrows
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class BrokenArrowsStatsController(IBrokenArrowsStatistiqueService service) : ControllerBase
    {
        private readonly IBrokenArrowsStatistiqueService _statistiquesService = service;

        [HttpGet(ConstUtils.STATS_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<StatsResponse>> GetAccidents()
        {
            StatsResponse stats = await _statistiquesService.GetAllStatsAsync();
            return stats == null ? NotFound() : Ok(stats);
        }
    }
}
