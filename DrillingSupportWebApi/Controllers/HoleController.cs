using DrillingSupportWebApi.Domain.Holes.Models;
using DrillingSupportWebApi.Domain.Holes.Services;
using DrillingSupportWebApi.ExceptionsHandling;
using Microsoft.AspNetCore.Mvc;

namespace DrillingSupportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleController : ControllerBase
    {
        private readonly HoleService _holeService;

        public HoleController(HoleService holeService)
        {
            _holeService = holeService;
        }

        // GET: api/<HolePointsController>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(HoleGetModel), 200)]
        public IActionResult Get(int id)
        {
            var foundItem = _holeService.Get(id);

            return foundItem == null ? NotFound() : Ok(foundItem);
        }

        // POST api/<HolePointsController>
        [HttpPost]
        public IActionResult Post([FromBody] HoleEditModel model)
        {
            var createdModel = _holeService.Create(model);

            return Ok(createdModel);
        }

        // PUT api/<HolePointsController>/5
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] HoleEditModel model)
        {
            var updatedModel = _holeService.Update(id, model);
            return updatedModel != null
                ? Ok(updatedModel)
                : ControllerExceptions.Failure();
        }

        // DELETE api/<HolePointsController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _holeService.TryRemove(id)
                ? Ok()
                : ControllerExceptions.Failure();
        }
    }
}
