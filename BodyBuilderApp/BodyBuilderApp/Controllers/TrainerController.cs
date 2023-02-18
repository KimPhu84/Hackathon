using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.TrainerModule.Interface;
using BodyBuilderApp.Modules.TrainerModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _TrainerService;

        public TrainersController(ITrainerService TrainerService)
        {
            _TrainerService = TrainerService;
        }

        // GET: api/Trainers
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            try
            {
                var response = await _TrainerService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer([FromRoute] string id)
        {
            var Trainer = await _TrainerService.GetTrainerByID(id);

            if (Trainer == null)
            {
                return NotFound();
            }

            return Trainer;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer([FromBody] CreateTrainerRequest createTrainerRequest)
        {
            var check = await _TrainerService.AddNewTrainer(createTrainerRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer([FromBody] UpdateTrainerRequest updateTrainerRequest)
        {
            var check = await _TrainerService.UpdateTrainer(updateTrainerRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/Trainers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTrainer([FromRoute] Guid id)
        //{
        //    var Trainer = await _TrainerService.GetTrainerByID(id);
        //    if (Trainer == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _TrainerService.(Trainer.BasketId);

        //    return Ok();
        //}

    }
}
