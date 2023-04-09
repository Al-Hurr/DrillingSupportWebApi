using DrillingSupportWebApi.Domain.DrillBlockPointsPointss.Services;
using DrillingSupportWebApi.Domain.DrillBlockPointss.Models;
using DrillingSupportWebApi.ExceptionsHandling;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrillingSupportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointsController : ControllerBase
    {
        private readonly DrillBlockPointsService _drillBlockPointsService;

        public DrillBlockPointsController(DrillBlockPointsService drillBlockPointsService)
        {
            _drillBlockPointsService = drillBlockPointsService;
        }

        // GET: api/<DrillBlockPointsController>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DrillBlockPointsGetModel), 200)]
        public IActionResult Get(int id)
        {
            var foundItem = _drillBlockPointsService.Get(id);

            return foundItem == null ? NotFound() : Ok(foundItem);
        }

        // POST api/<DrillBlockPointsController>
        [HttpPost]
        public IActionResult Post([FromBody]DrillBlockPointsEditModel model)
        {
            var createdModel = _drillBlockPointsService.Create(model);

            return Ok(createdModel);
        }

        // PUT api/<DrillBlockPointsController>/5
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]DrillBlockPointsEditModel model)
        {
            var updatedDrillBlock = _drillBlockPointsService.Update(id, model);
            return updatedDrillBlock != null
                ? Ok(updatedDrillBlock)
                : ControllerExceptions.Failure();
        }

        // DELETE api/<DrillBlockPointsController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _drillBlockPointsService.TryRemove(id)
                ? Ok()
                : ControllerExceptions.Failure();
        }
    }
}
