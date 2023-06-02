using Application.Barns;
using Application.Barns.Dtos;
using Application.Core;
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
    [Authorize]
    [ApiController]

    public class BarnsController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetBarns() 
        {
            var result = await Mediator.Send(new BarnList.Query());
            return HandleResult(result);
        }

        [HttpGet("short")]
        public async Task<ActionResult<List<CreateBarnDto>>> GetBarnsShort([FromQuery]BarnParams param)
        {
            var result = await Mediator.Send(new BarnListShort.Query {Params = param});
            return HandlePagedResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarn(Guid id)
        {
            var result = await Mediator.Send(new BarnDetails.Query { Id = id});

            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBarn([FromBody] CreateBarnDto barn)
        {
            return HandleResult(await Mediator.Send(new CreateBarn.Command { Barn = barn }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarn(Guid id, [FromBody] CreateBarnDto barn)
        {
            barn.Id = id;
            return HandleResult(await Mediator.Send(new UpdateBarn.Command { Barn = barn }));
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
