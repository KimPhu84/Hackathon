using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Interface;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Request;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyFoodDetailsController : ControllerBase
    {
        private readonly IDailyFoodDetailService _DailyFoodDetailService;

        public DailyFoodDetailsController(IDailyFoodDetailService DailyFoodDetailService)
        {
            _DailyFoodDetailService = DailyFoodDetailService;
        }

        // GET: api/DailyFoodDetails
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<DailyFoodDetail>>> GetDailyFoodDetails()
        {
            try
            {
                var response = await _DailyFoodDetailService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/DailyFoodDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyFoodDetail>> GetDailyFoodDetail([FromRoute] string id)
        {
            var DailyFoodDetail = await _DailyFoodDetailService.GetDailyFoodDetailByID(id);

            if (DailyFoodDetail == null)
            {
                return NotFound();
            }

            return DailyFoodDetail;
        }

        // PUT: api/DailyFoodDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyFoodDetail([FromBody] CreateDailyFoodDetailRequest createDailyFoodDetailRequest)
        {
            var check = await _DailyFoodDetailService.AddNewDailyFoodDetail(createDailyFoodDetailRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/DailyFoodDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyFoodDetail>> PostDailyFoodDetail([FromBody] UpdateDailyFoodDetailRequest updateDailyFoodDetailRequest)
        {
            var check = await _DailyFoodDetailService.UpdateDailyFoodDetail(updateDailyFoodDetailRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/DailyFoodDetails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDailyFoodDetail([FromRoute] Guid id)
        //{
        //    var DailyFoodDetail = await _DailyFoodDetailService.GetDailyFoodDetailByID(id);
        //    if (DailyFoodDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _DailyFoodDetailService.(DailyFoodDetail.BasketId);

        //    return Ok();
        //}

    }
}
