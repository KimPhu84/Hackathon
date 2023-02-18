using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.FoodDetailModule.Interface;

namespace BodyBuilderAppApp.Modules.FoodDetailModule
{
    public class FoodDetailRepository : Repository<FoodDetail>, IFoodDetailRepository
    {
        private readonly BodyBuilderAppContext _db;

        public FoodDetailRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<FoodDetail>> GetFoodDetailsBy(
            Expression<Func<FoodDetail, bool>> filter = null,
            Func<IQueryable<FoodDetail>, ICollection<FoodDetail>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<FoodDetail> query = DbSet;

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
