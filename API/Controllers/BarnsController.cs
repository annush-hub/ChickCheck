using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BarnsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarnsController(AppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Barn>>> GetBarns() 
        {
            return await _mediator.Send(new BarnList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Barn>> GetBarn(Guid id)
        {
            return Ok();
        }
    }
}
