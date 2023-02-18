using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Request;

namespace BodyBuilderApp.Modules.ScheduleExerciseModule.Interface
{
    public interface IScheduleExerciseService
    {
        public Task<ICollection<ScheduleExercise>> GetScheduleExercisesBy(
            Expression<Func<ScheduleExercise, bool>> filter = null,
            Func<IQueryable<ScheduleExercise>, ICollection<ScheduleExercise>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewScheduleExercise(CreateScheduleExerciseRequest ScheduleExerciseCreate);

        public Task<Boolean> UpdateScheduleExercise(UpdateScheduleExerciseRequest ScheduleExerciseUpdate);

        //public Task<Boolean> DeleteScheduleExercise(ScheduleExercise ScheduleExerciseDelete);

        public Task<ICollection<ScheduleExercise>> GetAll();

        public Task<ScheduleExercise> GetScheduleExerciseByID(string id);
    }
}
