using Application.Barns;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Diagnostics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BarnsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Barn>>> GetBarns() 
        {
            return await Mediator.Send(new BarnList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Barn>> GetBarn(Guid id)
        {
            return await Mediator.Send(new BarnDetails.Query { Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateBarn(Barn barn)
        {
            return Ok(await Mediator.Send(new CreateBarn.Command { Barn = barn }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarn(Guid id, Barn barn)
        {
            barn.Id = id;
            return Ok(await Mediator.Send(new UpdateBarn.Command { Barn = barn }));
        }
    }
}
