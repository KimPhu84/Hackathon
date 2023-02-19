using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.TargetModule.Interface;
using BodyBuilderApp.Modules.TargetModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private readonly ITargetService _TargetService;

        public TargetsController(ITargetService TargetService)
        {
            _TargetService = TargetService;
        }

        // GET: api/Targets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Target>>> GetTargets()
        {
            try
            {
                var response = await _TargetService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Targets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Target>> GetTarget([FromRoute] string id)
        {
            var Target = await _TargetService.GetTargetByID(id);

            if (Target == null)
            {
                return NotFound();
            }

            return Target;
        }

        // PUT: api/Targets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTarget([FromBody] CreateTargetRequest createTargetRequest)
        {
            var check = await _TargetService.AddNewTarget(createTargetRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/Targets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Target>> PostTarget([FromBody] UpdateTargetRequest updateTargetRequest)
        {
            var check = await _TargetService.UpdateTarget(updateTargetRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/Targets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTarget([FromRoute] Guid id)
        //{
        //    var Target = await _TargetService.GetTargetByID(id);
        //    if (Target == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _TargetService.(Target.BasketId);

        //    return Ok();
        //}

    }
}
