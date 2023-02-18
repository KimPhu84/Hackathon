using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Request;

namespace BodyBuilderApp.Modules.DailyFoodDetailModule.Interface
{
    public interface IDailyFoodDetailService
    {
        public Task<ICollection<DailyFoodDetail>> GetDailyFoodDetailsBy(
            Expression<Func<DailyFoodDetail, bool>> filter = null,
            Func<IQueryable<DailyFoodDetail>, ICollection<DailyFoodDetail>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewDailyFoodDetail(CreateDailyFoodDetailRequest DailyFoodDetailCreate);

        public Task<Boolean> UpdateDailyFoodDetail(UpdateDailyFoodDetailRequest DailyFoodDetailUpdate);

        //public Task<Boolean> DeleteDailyFoodDetail(DailyFoodDetail DailyFoodDetailDelete);

        public Task<ICollection<DailyFoodDetail>> GetAll();

        public Task<DailyFoodDetail> GetDailyFoodDetailByID(string id);
    }
}
