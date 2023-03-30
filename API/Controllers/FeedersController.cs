using Application.Barns.Dtos;
using Application.Barns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Feeders;
using Domain;
using Application.Feeders.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedersController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateFeeder([FromBody] FeederDto feeder)
        {
            return Ok(await Mediator.Send(new CreateFeeder.Command { Feeder = feeder }));
        }
    }
}
