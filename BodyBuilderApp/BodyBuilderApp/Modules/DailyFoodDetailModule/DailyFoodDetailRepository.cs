using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.DailyFoodDetailModule.Interface;

namespace BodyBuilderAppApp.Modules.DailyFoodDetailModule
{
    public class DailyFoodDetailRepository : Repository<DailyFoodDetail>, IDailyFoodDetailRepository
    {
        private readonly BodyBuilderAppContext _db;

        public DailyFoodDetailRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<DailyFoodDetail>> GetDailyFoodDetailsBy(
            Expression<Func<DailyFoodDetail, bool>> filter = null,
            Func<IQueryable<DailyFoodDetail>, ICollection<DailyFoodDetail>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<DailyFoodDetail> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return options != null ? options(query).ToList() : await query.ToListAsync();
        }
    }
}
