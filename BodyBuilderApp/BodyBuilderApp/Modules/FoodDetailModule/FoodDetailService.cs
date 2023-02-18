using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.FoodDetailModule.Interface;
using BodyBuilderApp.Modules.FoodDetailModule.Request;

namespace BodyBuilderApp.Modules.FoodDetailModule
{
    public class FoodDetailService : IFoodDetailService
    {
        private readonly IFoodDetailRepository _FoodDetailRepository;
        public FoodDetailService(IFoodDetailRepository FoodDetailRepository)
        {
            _FoodDetailRepository = FoodDetailRepository;
        }

        public async Task<ICollection<FoodDetail>> GetAll()
        {
            return await _FoodDetailRepository.GetAll();
        }

        public Task<ICollection<FoodDetail>> GetFoodDetailsBy(
                Expression<Func<FoodDetail,
                bool>> filter = null,
                Func<IQueryable<FoodDetail>,
                ICollection<FoodDetail>> options = null,
                string includeProperties = null)
        {
            return _FoodDetailRepository.GetFoodDetailsBy(filter);
        }


        public async Task<Boolean> AddNewFoodDetail(CreateFoodDetailRequest FoodDetailRequest)
        {
            var newFoodDetail = new FoodDetail();

            newFoodDetail.FoodName = FoodDetailRequest.FoodName;
            newFoodDetail.Calories = FoodDetailRequest.Calories;
            newFoodDetail.Image = FoodDetailRequest.Image;

            await _FoodDetailRepository.AddAsync(newFoodDetail);
            return true;
        }

        public async Task<Boolean> UpdateFoodDetail(UpdateFoodDetailRequest FoodDetailRequest)
        {
            var FoodDetailUpdate = GetFoodDetailByID(FoodDetailRequest.FoodName).Result;

            FoodDetailUpdate.Calories = FoodDetailRequest.Calories;
            FoodDetailUpdate.Image = FoodDetailRequest.Image;
            await _FoodDetailRepository.UpdateAsync(FoodDetailUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteFoodDetail(FoodDetail FoodDetailDelete)
        //{
        //    FoodDetailDelete.Status = 0;
        //    await _FoodDetailRepository.UpdateAsync(FoodDetailDelete);
        //    return true;
        //}

        public async Task<FoodDetail> GetFoodDetailByID(string id)
        {
            return await _FoodDetailRepository.GetFirstOrDefaultAsync(x => x.FoodName == id);
        }
    }
}
