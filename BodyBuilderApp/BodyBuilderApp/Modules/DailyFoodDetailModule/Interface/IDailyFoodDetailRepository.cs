using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.DailyFoodDetailModule.Interface
{
    public interface IDailyFoodDetailRepository : IRepository<DailyFoodDetail>
    {
        public Task<ICollection<DailyFoodDetail>> GetDailyFoodDetailsBy(
             Expression<Func<DailyFoodDetail, bool>> filter = null,
             Func<IQueryable<DailyFoodDetail>, ICollection<DailyFoodDetail>> options = null,
             string includeProperties = null
         );
    }
}
