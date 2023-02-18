using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.BodyStatusModule.Interface;

namespace BodyBuilderAppApp.Modules.BodyStatusModule
{
    public class BodyStatusRepository : Repository<BodyStatus>, IBodyStatusRepository
    {
        private readonly BodyBuilderAppContext _db;

        public BodyStatusRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<BodyStatus>> GetBodyStatussBy(
            Expression<Func<BodyStatus, bool>> filter = null,
            Func<IQueryable<BodyStatus>, ICollection<BodyStatus>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<BodyStatus> query = DbSet;

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
