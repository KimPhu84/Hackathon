using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Interface;

namespace BodyBuilderAppApp.Modules.ScheduleExerciseModule
{
    public class ScheduleExerciseRepository : Repository<ScheduleExercise>, IScheduleExerciseRepository
    {
        private readonly BodyBuilderAppContext _db;

        public ScheduleExerciseRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<ScheduleExercise>> GetScheduleExercisesBy(
            Expression<Func<ScheduleExercise, bool>> filter = null,
            Func<IQueryable<ScheduleExercise>, ICollection<ScheduleExercise>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<ScheduleExercise> query = DbSet;

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
