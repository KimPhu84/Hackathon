using Microsoft.AspNetCore.Mvc;
using BodyBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BodyBuilderApp.Modules.FoodDetailModule.Interface;
using BodyBuilderApp.Modules.FoodDetailModule.Request;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Traibanhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDetailsController : ControllerBase
    {
        private readonly IFoodDetailService _FoodDetailService;

        public FoodDetailsController(IFoodDetailService FoodDetailService)
        {
            _FoodDetailService = FoodDetailService;
        }

        // GET: api/FoodDetails
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<FoodDetail>>> GetFoodDetails()
        {
            try
            {
                var response = await _FoodDetailService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/FoodDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDetail>> GetFoodDetail([FromRoute] string id)
        {
            var FoodDetail = await _FoodDetailService.GetFoodDetailByID(id);

            if (FoodDetail == null)
            {
                return NotFound();
            }

            return FoodDetail;
        }

        // PUT: api/FoodDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutFoodDetail([FromBody] CreateFoodDetailRequest createFoodDetailRequest)
        {
            var check = await _FoodDetailService.AddNewFoodDetail(createFoodDetailRequest);
            if(check) return Ok();
            else return BadRequest();
        }

        // POST: api/FoodDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodDetail>> PostFoodDetail([FromBody] UpdateFoodDetailRequest updateFoodDetailRequest)
        {
            var check = await _FoodDetailService.UpdateFoodDetail(updateFoodDetailRequest);
            if (check) return Ok();
            else return BadRequest();
        }

        //// DELETE: api/FoodDetails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFoodDetail([FromRoute] Guid id)
        //{
        //    var FoodDetail = await _FoodDetailService.GetFoodDetailByID(id);
        //    if (FoodDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    //await _typeService.DeleteType(type);
        //    await _FoodDetailService.(FoodDetail.BasketId);

        //    return Ok();
        //}

    }
}
