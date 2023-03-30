using Application.Barns;
using Application.EggGrades;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EggGradesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<EggGrade>>> GetEggGrades()
        {
            return await Mediator.Send(new EggGradeList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EggGrade>> GetEggGrade(Guid id)
        {
            return await Mediator.Send(new EggGradeDetails.Query { Id = id });
        }
    }
}
