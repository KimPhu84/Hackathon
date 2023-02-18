using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.FoodDetailModule.Request;

namespace BodyBuilderApp.Modules.FoodDetailModule.Interface
{
    public interface IFoodDetailService
    {
        public Task<ICollection<FoodDetail>> GetFoodDetailsBy(
            Expression<Func<FoodDetail, bool>> filter = null,
            Func<IQueryable<FoodDetail>, ICollection<FoodDetail>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewFoodDetail(CreateFoodDetailRequest FoodDetailCreate);

        public Task<Boolean> UpdateFoodDetail(UpdateFoodDetailRequest FoodDetailUpdate);

        //public Task<Boolean> DeleteFoodDetail(FoodDetail FoodDetailDelete);

        public Task<ICollection<FoodDetail>> GetAll();

        public Task<FoodDetail> GetFoodDetailByID(string id);
    }
}
