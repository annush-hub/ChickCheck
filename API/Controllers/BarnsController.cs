using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarnsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BarnsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Barn>>> GetBarns() 
        {
            return await _context.Barns.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Barn>> GetBarn(Guid id)
        {
            return await _context.Barns.FindAsync(id);
        }
    }
}
