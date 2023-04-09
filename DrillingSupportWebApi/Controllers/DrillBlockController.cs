using DrillingSupportWebApi.Domain.DrillBlocks.Models;
using DrillingSupportWebApi.Domain.DrillBlocks.Services;
using DrillingSupportWebApi.ExceptionsHandling;
using Microsoft.AspNetCore.Mvc;

namespace DrillingSupportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : ControllerBase
    {
        private readonly DrillBlockService _drillBlockService;

        public DrillBlockController(DrillBlockService drillBlockService)
        {
            _drillBlockService = drillBlockService;
        }

        // GET: api/<DrillBlockPointsController>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DrillBlockGetModel), 200)]
        public IActionResult Get(int id)
        {
            var foundItem = _drillBlockService.Get(id);

            return foundItem == null ? NotFound() : Ok(foundItem);
        }

        // POST api/<DrillBlockPointsController>
        [HttpPost]
        public IActionResult Post([FromBody] DrillBlockEditModel model)
        {
            var createdModel = _drillBlockService.Create(model);

            return Ok(createdModel);
        }

        // PUT api/<DrillBlockPointsController>/5
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] DrillBlockEditModel model)
        {
            var updatedModel = _drillBlockService.Update(id, model);
            return updatedModel != null
                ? Ok(updatedModel)
                : ControllerExceptions.Failure();
        }

        // DELETE api/<DrillBlockPointsController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _drillBlockService.TryRemove(id)
                ? Ok()
                : ControllerExceptions.Failure();
        }
    }
}
