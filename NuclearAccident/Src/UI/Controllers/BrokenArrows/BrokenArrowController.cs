using Microsoft.AspNetCore.Mvc;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Services.Interfaces.BrokenArrows;
using System.Net.Mime;

namespace NuclearAccident.Src.UI.Controllers.BrokenArrows
{
    [Route(ConstUtils.ROOT_URL)]
    [ApiController]
    public class BrokenArrowController(IbrokenArrowsService service) : ControllerBase
    {
        private readonly IbrokenArrowsService _accidentService = service;

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<AccidentResponse>>> GetAccidents()
        {
            IEnumerable<AccidentResponse> accidents = await _accidentService.GetAccidentsAsync();
            return accidents == null || !accidents.Any() ? NotFound() : Ok(accidents);
        }

        [HttpPost("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<AccidentResponse>> GetSingleAccidentAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ConstUtils.INVALID_GUID);
            }
            else
            {
                AccidentResponse? accident = await _accidentService.GetSingleAccidentAsync(id);
                return accident == null ? NotFound() : Ok(accident);
            }
        }

        [HttpPost("/years/{year}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<AccidentResponse>> GetAccidentsByYearsAsync([FromRoute] AvailableYear year)
        {
            IEnumerable<AccidentResponse> accidents = await _accidentService.GetAccidentsByYearsAsync((int)year);
            return accidents == null ? NotFound() : Ok(accidents);
        }
    }
}

