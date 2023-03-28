using Application.Barns;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

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
            return Ok();
        }
    }
}
