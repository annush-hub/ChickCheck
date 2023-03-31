using Application.Barns;
using Application.EggGrades;
using Application.Feeders;
using Application.Storages;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<StorageDetailedDto>>> GetStorages()
        {
            return await Mediator.Send(new StorageList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageDetailedDto>> GetStorage(Guid id)
        {
            return await Mediator.Send(new StorageDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorage([FromBody] StorageDto storage)
        {
            return Ok(await Mediator.Send(new CreateStorage.Command { Storage = storage }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStorage(Guid id, [FromBody] StorageDto storage)
        {
            storage.Id = id;
            return Ok(await Mediator.Send(new UpdateStorage.Command { Storage = storage }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteStorage.Command { Id = id }));
        }

        [HttpPost("{id}/addEggGrade")]
        public async Task<IActionResult> CreateEggGradeStorage(Guid id, [FromBody] EggGardeStorageDto eggGradeStorage)
        {
            return Ok(await Mediator.Send(new CreateEggGradeStorage.Command { EggGradeId = eggGradeStorage.EggGradeId, StorageId = id }));
        }

        [HttpDelete("{id}/deleteEggGrade")]
        public async Task<IActionResult> DeleteEggGradeStorage(Guid id, [FromBody] EggGardeStorageDto eggGradeStorage)
        {
            return Ok(await Mediator.Send(new DeleteEggGradeStorage.Command { EggGradeId = eggGradeStorage.EggGradeId, StorageId = id }));
        }
    }
}
