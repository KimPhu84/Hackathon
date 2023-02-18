using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.ExerciseModule.Interface
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        public Task<ICollection<Exercise>> GetExercisesBy(
             Expression<Func<Exercise, bool>> filter = null,
             Func<IQueryable<Exercise>, ICollection<Exercise>> options = null,
             string includeProperties = null
         );
    }
}
