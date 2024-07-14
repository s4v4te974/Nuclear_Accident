using Microsoft.AspNetCore.Mvc;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Services.Interfaces.BrokenArrows;
using System.Net.Mime;

namespace NuclearIncident.Src.UI.Controllers.BrokenArrows
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class BrokenArrowController(IbrokenArrowsService service) : ControllerBase
    {
        private readonly IbrokenArrowsService _BrokenArrowsService = service;

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<BrokenArrowResponse>>> GetBrokenArrowss()
        {
            IEnumerable<BrokenArrowResponse> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssAsync();
            return BrokenArrowss == null || !BrokenArrowss.Any() ? NotFound() : Ok(BrokenArrowss);
        }

        [HttpPost("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<BrokenArrowResponse>> GetSingleBrokenArrowsAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                BrokenArrowResponse? BrokenArrows = await _BrokenArrowsService.GetSingleBrokenArrowsAsync(id);
                return BrokenArrows == null ? NotFound() : Ok(BrokenArrows);
            }
        }

        [HttpPost("/years/{year}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<BrokenArrowResponse>> GetBrokenArrowssByYearsAsync([FromRoute] AvailableYear year)
        {
            IEnumerable<BrokenArrowResponse> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssByYearsAsync((int)year);
            return BrokenArrowss == null ? NotFound() : Ok(BrokenArrowss);
        }
    }
}

