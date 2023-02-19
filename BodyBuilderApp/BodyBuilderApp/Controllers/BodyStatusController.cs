using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.BodyStatusModule.Interface;
using BodyBuilderApp.Modules.BodyStatusModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyStatussController : ControllerBase
    {
        private readonly IBodyStatusService _BodyStatusService;

        public BodyStatussController(IBodyStatusService BodyStatusService)
        {
            _BodyStatusService = BodyStatusService;
        }

        // GET: api/BodyStatuss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyStatus>>> GetBodyStatuss()
        {
            try
            {
                var response = await _BodyStatusService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/BodyStatuss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyStatus>> GetBodyStatus([FromRoute] string id)
        {
            var BodyStatus = await _BodyStatusService.GetBodyStatusByID(id);

            if (BodyStatus == null)
            {
                return NotFound();
            }

            return BodyStatus;
        }

        // PUT: api/BodyStatuss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutBodyStatus([FromBody] CreateBodyStatusRequest createBodyStatusRequest)
        {
            var check = await _BodyStatusService.AddNewBodyStatus(createBodyStatusRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/BodyStatuss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BodyStatus>> PostBodyStatus([FromBody] UpdateBodyStatusRequest updateBodyStatusRequest)
        {
            var check = await _BodyStatusService.UpdateBodyStatus(updateBodyStatusRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/BodyStatuss/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBodyStatus([FromRoute] Guid id)
        //{
        //    var BodyStatus = await _BodyStatusService.GetBodyStatusByID(id);
        //    if (BodyStatus == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _BodyStatusService.(BodyStatus.BasketId);

        //    return Ok();
        //}

    }
}
