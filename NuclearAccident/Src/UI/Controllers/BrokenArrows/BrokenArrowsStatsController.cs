using Microsoft.AspNetCore.Mvc;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Services.Interfaces.BrokenArrows;
using System.Net.Mime;

namespace NuclearIncident.Src.UI.Controllers.BrokenArrows
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class BrokenArrowsStatsController(IBrokenArrowsStatistiqueService service) : ControllerBase
    {
        private readonly IBrokenArrowsStatistiqueService _statistiquesService = service;

        [HttpGet(ConstUtils.STATS_URL)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<AccidentStatsResponse>> GetAccidents()
        {
            AccidentStatsResponse stats = await _statistiquesService.GetAllStatsAsync();
            return stats == null ? NotFound() : Ok(stats);
        }
    }
}
