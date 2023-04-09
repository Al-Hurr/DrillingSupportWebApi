using DrillingSupportWebApi.Domain.HolePointss.Models;
using DrillingSupportWebApi.Domain.HolePointsss.Services;
using DrillingSupportWebApi.ExceptionsHandling;
using Microsoft.AspNetCore.Mvc;

namespace DrillingSupportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointsController : ControllerBase
    {
        private readonly HolePointsService _holePointsService;

        public HolePointsController(HolePointsService holePointsService)
        {
            _holePointsService = holePointsService;
        }

        // GET: api/<HolePointsPointsController>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(HolePointsGetModel), 200)]
        public IActionResult Get(int id)
        {
            var foundItem = _holePointsService.Get(id);

            return foundItem == null ? NotFound() : Ok(foundItem);
        }

        // POST api/<HolePointsPointsController>
        [HttpPost]
        public IActionResult Post([FromBody] HolePointsEditModel model)
        {
            var createdModel = _holePointsService.Create(model);

            return Ok(createdModel);
        }

        // PUT api/<HolePointsPointsController>/5
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] HolePointsEditModel model)
        {
            var updatedModel = _holePointsService.Update(id, model);
            return updatedModel != null
                ? Ok(updatedModel)
                : ControllerExceptions.Failure();
        }

        // DELETE api/<HolePointsPointsController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _holePointsService.TryRemove(id)
                ? Ok()
                : ControllerExceptions.Failure();
        }
    }
}
