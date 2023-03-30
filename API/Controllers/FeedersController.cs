using Application.Barns.Dtos;
using Application.Barns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Feeders;
using Domain;
using Application.EggGrades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<FeederDto>>> GetFeeders()
        {
            return await Mediator.Send(new FeederList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeederDto>> GetFeeder(Guid id)
        {
            return await Mediator.Send(new FeederDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeder([FromBody] FeederDto feeder)
        {
            return Ok(await Mediator.Send(new CreateFeeder.Command { Feeder = feeder }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatefeeder(Guid id, [FromBody] FeederDto feeder)
        {
            feeder.Id = id;
            return Ok(await Mediator.Send(new UpdateFeeder.Command { Feeder = feeder }));
        }
    }
}
