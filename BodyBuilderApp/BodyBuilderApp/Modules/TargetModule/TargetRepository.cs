using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TargetModule.Interface;

namespace BodyBuilderAppApp.Modules.TargetModule
{
    public class TargetRepository : Repository<Target>, ITargetRepository
    {
        private readonly BodyBuilderAppContext _db;

        public TargetRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<Target>> GetTargetsBy(
            Expression<Func<Target, bool>> filter = null,
            Func<IQueryable<Target>, ICollection<Target>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Target> query = DbSet;

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
