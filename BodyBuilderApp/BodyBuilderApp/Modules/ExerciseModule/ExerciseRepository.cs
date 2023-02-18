using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ExerciseModule.Interface;

namespace BodyBuilderAppApp.Modules.ExerciseModule
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly BodyBuilderAppContext _db;

        public ExerciseRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<Exercise>> GetExercisesBy(
            Expression<Func<Exercise, bool>> filter = null,
            Func<IQueryable<Exercise>, ICollection<Exercise>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Exercise> query = DbSet;

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
