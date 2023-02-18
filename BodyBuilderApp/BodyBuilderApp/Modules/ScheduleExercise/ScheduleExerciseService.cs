using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Interface;
using BodyBuilderApp.Modules.ScheduleExerciseModule.Request;

namespace BodyBuilderApp.Modules.ScheduleExerciseModule
{
    public class ScheduleExerciseService : IScheduleExerciseService
    {
        private readonly IScheduleExerciseRepository _ScheduleExerciseRepository;
        public ScheduleExerciseService(IScheduleExerciseRepository ScheduleExerciseRepository)
        {
            _ScheduleExerciseRepository = ScheduleExerciseRepository;
        }

        public async Task<ICollection<ScheduleExercise>> GetAll()
        {
            return await _ScheduleExerciseRepository.GetAll();
        }

        public Task<ICollection<ScheduleExercise>> GetScheduleExercisesBy(
                Expression<Func<ScheduleExercise,
                bool>> filter = null,
                Func<IQueryable<ScheduleExercise>,
                ICollection<ScheduleExercise>> options = null,
                string includeProperties = null)
        {
            return _ScheduleExerciseRepository.GetScheduleExercisesBy(filter);
        }


        public async Task<Boolean> AddNewScheduleExercise(CreateScheduleExerciseRequest ScheduleExerciseRequest)
        {
            var newScheduleExercise = new ScheduleExercise();

            newScheduleExercise.UserId = ScheduleExerciseRequest.UserId;
            newScheduleExercise.ScheduleId = ScheduleExerciseRequest.ScheduleId;
            newScheduleExercise.ExerciseId = ScheduleExerciseRequest.ExerciseId;

            await _ScheduleExerciseRepository.AddAsync(newScheduleExercise);
            return true;
        }

        public async Task<Boolean> UpdateScheduleExercise(UpdateScheduleExerciseRequest ScheduleExerciseRequest)
        {
            var ScheduleExerciseUpdate = new ScheduleExercise();

            ScheduleExerciseUpdate.UserId = ScheduleExerciseRequest.UserId;
            ScheduleExerciseUpdate.ScheduleId = ScheduleExerciseRequest.ScheduleId;
            ScheduleExerciseUpdate.ExerciseId = ScheduleExerciseRequest.ExerciseId;
            await _ScheduleExerciseRepository.UpdateAsync(ScheduleExerciseUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteScheduleExercise(ScheduleExercise ScheduleExerciseDelete)
        //{
        //    ScheduleExerciseDelete.Status = 0;
        //    await _ScheduleExerciseRepository.UpdateAsync(ScheduleExerciseDelete);
        //    return true;
        //}

        public async Task<ScheduleExercise> GetScheduleExerciseByID(string id)
        {
            return await _ScheduleExerciseRepository.GetFirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
