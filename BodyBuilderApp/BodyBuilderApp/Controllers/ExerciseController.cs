using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.ExerciseModule.Interface;
using BodyBuilderApp.Modules.ExerciseModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _ExerciseService;

        public ExercisesController(IExerciseService ExerciseService)
        {
            _ExerciseService = ExerciseService;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            try
            {
                var response = await _ExerciseService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise([FromRoute] string id)
        {
            var Exercise = await _ExerciseService.GetExerciseByID(id);

            if (Exercise == null)
            {
                return NotFound();
            }

            return Exercise;
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutExercise([FromBody] CreateExerciseRequest createExerciseRequest)
        {
            var check = await _ExerciseService.AddNewExercise(createExerciseRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise([FromBody] UpdateExerciseRequest updateExerciseRequest)
        {
            var check = await _ExerciseService.UpdateExercise(updateExerciseRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/Exercises/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteExercise([FromRoute] Guid id)
        //{
        //    var Exercise = await _ExerciseService.GetExerciseByID(id);
        //    if (Exercise == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _ExerciseService.(Exercise.BasketId);

        //    return Ok();
        //}

    }
}
