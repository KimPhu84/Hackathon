using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Interface;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleExercisesController : ControllerBase
    {
        private readonly IScheduleExerciseService _ScheduleExerciseService;

        public ScheduleExercisesController(IScheduleExerciseService ScheduleExerciseService)
        {
            _ScheduleExerciseService = ScheduleExerciseService;
        }

        // GET: api/ScheduleExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleExercise>>> GetScheduleExercises()
        {
            try
            {
                var response = await _ScheduleExerciseService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/ScheduleExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleExercise>> GetScheduleExercise([FromRoute] string id)
        {
            var ScheduleExercise = await _ScheduleExerciseService.GetScheduleExerciseByID(id);

            if (ScheduleExercise == null)
            {
                return NotFound();
            }

            return ScheduleExercise;
        }

        // PUT: api/ScheduleExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutScheduleExercise([FromBody] CreateScheduleExerciseRequest createScheduleExerciseRequest)
        {
            var check = await _ScheduleExerciseService.AddNewScheduleExercise(createScheduleExerciseRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/ScheduleExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleExercise>> PostScheduleExercise([FromBody] UpdateScheduleExerciseRequest updateScheduleExerciseRequest)
        {
            var check = await _ScheduleExerciseService.UpdateScheduleExercise(updateScheduleExerciseRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/ScheduleExercises/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteScheduleExercise([FromRoute] Guid id)
        //{
        //    var ScheduleExercise = await _ScheduleExerciseService.GetScheduleExerciseByID(id);
        //    if (ScheduleExercise == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _ScheduleExerciseService.(ScheduleExercise.BasketId);

        //    return Ok();
        //}

    }
}
