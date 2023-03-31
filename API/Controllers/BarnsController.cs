using Application.Barns;
using Application.Barns.Dtos;
using Application.Storages;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<BarnDto>>> GetBarns() 
        {
            return await Mediator.Send(new BarnList.Query());
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<BarnDto>> GetBarn(Guid id)
        {
            return await Mediator.Send(new BarnDetails.Query { Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateBarn([FromBody] CreateBarnDto barn)
        {
            return Ok(await Mediator.Send(new CreateBarn.Command { Barn = barn }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarn(Guid id, [FromBody] CreateBarnDto barn)
        {
            barn.Id = id;
            return Ok(await Mediator.Send(new UpdateBarn.Command { Barn = barn }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarn(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteBarn.Command { Id = id }));
        }

        [HttpPost("{id}/addCleaning")]
        public async Task<IActionResult> CreateBarnCleaning(Guid id, [FromBody] CleaningDto cleaning)
        {
            return Ok(await Mediator.Send(new CreateBarnCleaning.Command { AppUserId = cleaning.AppUserId, BarnId = id }));
        }

        [HttpGet("{id}/getCleanings")]
        public async Task<IActionResult> GetBarnCleanings(Guid id)
        {
            return Ok(await Mediator.Send(new BarnCleaningList.Query { BarnId = id }));
        }

        [HttpGet("{id}/getLastCleaning")]
        public async Task<IActionResult> GetBarnLastCleaning(Guid id)
        {
            return Ok(await Mediator.Send(new BarnLastCleaning.Query { BarnId = id }));
        }

        [HttpGet("{id}/getCleaningCounter")]
        public async Task<IActionResult> GetBarnCleaningCounter(Guid id)
        {
            return Ok(await Mediator.Send(new BarnCleaningCounter.Query { BarnId = id }));
        }
    }
}
