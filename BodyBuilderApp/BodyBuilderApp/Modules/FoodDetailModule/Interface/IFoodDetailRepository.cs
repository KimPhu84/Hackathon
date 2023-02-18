using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.FoodDetailModule.Interface
{
    public interface IFoodDetailRepository : IRepository<FoodDetail>
    {
        public Task<ICollection<FoodDetail>> GetFoodDetailsBy(
             Expression<Func<FoodDetail, bool>> filter = null,
             Func<IQueryable<FoodDetail>, ICollection<FoodDetail>> options = null,
             string includeProperties = null
         );
    }
}
