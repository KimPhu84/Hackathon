using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Interface;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Request;

namespace BodyBuilderApp.Modules.DailyFoodDetailModule
{
    public class DailyFoodDetailService : IDailyFoodDetailService
    {
        private readonly IDailyFoodDetailRepository _DailyFoodDetailRepository;
        public DailyFoodDetailService(IDailyFoodDetailRepository DailyFoodDetailRepository)
        {
            _DailyFoodDetailRepository = DailyFoodDetailRepository;
        }

        public async Task<ICollection<DailyFoodDetail>> GetAll()
        {
            return await _DailyFoodDetailRepository.GetAll();
        }

        public Task<ICollection<DailyFoodDetail>> GetDailyFoodDetailsBy(
                Expression<Func<DailyFoodDetail,
                bool>> filter = null,
                Func<IQueryable<DailyFoodDetail>,
                ICollection<DailyFoodDetail>> options = null,
                string includeProperties = null)
        {
            return _DailyFoodDetailRepository.GetDailyFoodDetailsBy(filter);
        }


        public async Task<Boolean> AddNewDailyFoodDetail(CreateDailyFoodDetailRequest DailyFoodDetailRequest)
        {
            var newDailyFoodDetail = new DailyFoodDetail();

            newDailyFoodDetail.DailyFoodDetailId = DailyFoodDetailRequest.DailyFoodDetailId;
            newDailyFoodDetail.DailyFoodId = DailyFoodDetailRequest.DailyFoodId;
            newDailyFoodDetail.FoodName= DailyFoodDetailRequest.FoodName;
            newDailyFoodDetail.TimeToEat= DailyFoodDetailRequest.TimeToEat;
            newDailyFoodDetail.Recommend = DailyFoodDetailRequest.Recommend;

            await _DailyFoodDetailRepository.AddAsync(newDailyFoodDetail);
            return true;
        }

        public async Task<Boolean> UpdateDailyFoodDetail(UpdateDailyFoodDetailRequest DailyFoodDetailRequest)
        {
            var DailyFoodDetailUpdate = GetDailyFoodDetailByID(DailyFoodDetailRequest.DailyFoodDetailId).Result;

            DailyFoodDetailUpdate.DailyFoodDetailId = DailyFoodDetailRequest.DailyFoodDetailId;
            DailyFoodDetailUpdate.DailyFoodId = DailyFoodDetailRequest.DailyFoodId;
            DailyFoodDetailUpdate.FoodName = DailyFoodDetailRequest.FoodName;
            DailyFoodDetailUpdate.TimeToEat = DailyFoodDetailRequest.TimeToEat;
            DailyFoodDetailUpdate.Recommend = DailyFoodDetailRequest.Recommend;
            await _DailyFoodDetailRepository.UpdateAsync(DailyFoodDetailUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteDailyFoodDetail(DailyFoodDetail DailyFoodDetailDelete)
        //{
        //    DailyFoodDetailDelete.Status = 0;
        //    await _DailyFoodDetailRepository.UpdateAsync(DailyFoodDetailDelete);
        //    return true;
        //}

        public async Task<DailyFoodDetail> GetDailyFoodDetailByID(string id)
        {
            return await _DailyFoodDetailRepository.GetFirstOrDefaultAsync(x => x.DailyFoodDetailId == id);
        }
    }
}
