using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.ScheduleExerciseModule.Interface
{
    public interface IScheduleExerciseRepository : IRepository<ScheduleExercise>
    {
        public Task<ICollection<ScheduleExercise>> GetScheduleExercisesBy(
             Expression<Func<ScheduleExercise, bool>> filter = null,
             Func<IQueryable<ScheduleExercise>, ICollection<ScheduleExercise>> options = null,
             string includeProperties = null
         );
    }
}
