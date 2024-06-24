using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Controllers
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class BrokenArrowsController(IBrokenArrowService service) : ControllerBase
    {
        private readonly IBrokenArrowService _brokenArrowService = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrokenArrowResponse>>> GetBrokenArrows()
        {
            IEnumerable<BrokenArrowResponse> brokenArrows = await _brokenArrowService.GetBrokenArrowsAsync();
            return brokenArrows == null || !brokenArrows.Any() ? NotFound() : Ok(brokenArrows);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<BrokenArrowResponse>> GetSingleBrokenArrowAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                BrokenArrowResponse? brokenArrow = await _brokenArrowService.GetSingleBrokenArrowAsync(id);
                return brokenArrow == null ? NotFound() : Ok(brokenArrow);
            }
        }

        [HttpPost("/years/{year}")]
        public async Task<ActionResult<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync([FromRoute] AvailableYear year)
        {
            IEnumerable<BrokenArrowResponse> brokenArrows = await _brokenArrowService.GetBrokenArrowsByYearsAsync((int)year);
            return brokenArrows == null ? NotFound() : Ok(brokenArrows);
        }
    }
}

