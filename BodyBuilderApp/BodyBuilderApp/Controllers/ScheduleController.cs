using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.ScheduleModule.Interface;
using BodyBuilderApp.Modules.ScheduleModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _ScheduleService;

        public SchedulesController(IScheduleService ScheduleService)
        {
            _ScheduleService = ScheduleService;
        }

        // GET: api/Schedules
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            try
            {
                var response = await _ScheduleService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule([FromRoute] string id)
        {
            var Schedule = await _ScheduleService.GetScheduleByID(id);

            if (Schedule == null)
            {
                return NotFound();
            }

            return Schedule;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule([FromBody] CreateScheduleRequest createScheduleRequest)
        {
            var check = await _ScheduleService.AddNewSchedule(createScheduleRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule([FromBody] UpdateScheduleRequest updateScheduleRequest)
        {
            var check = await _ScheduleService.UpdateSchedule(updateScheduleRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/Schedules/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSchedule([FromRoute] Guid id)
        //{
        //    var Schedule = await _ScheduleService.GetScheduleByID(id);
        //    if (Schedule == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _ScheduleService.(Schedule.BasketId);

        //    return Ok();
        //}

    }
}
