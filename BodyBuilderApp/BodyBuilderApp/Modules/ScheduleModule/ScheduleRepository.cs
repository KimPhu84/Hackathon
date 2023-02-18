using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleModule.Interface;

namespace BodyBuilderAppApp.Modules.ScheduleModule
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private readonly BodyBuilderAppContext _db;

        public ScheduleRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<Schedule>> GetSchedulesBy(
            Expression<Func<Schedule, bool>> filter = null,
            Func<IQueryable<Schedule>, ICollection<Schedule>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Schedule> query = DbSet;

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
