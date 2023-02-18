using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ExerciseModule.Interface;
using BodyBuilderApp.Modules.ExerciseModule.Request;

namespace BodyBuilderApp.Modules.ExerciseModule
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _ExerciseRepository;
        public ExerciseService(IExerciseRepository ExerciseRepository)
        {
            _ExerciseRepository = ExerciseRepository;
        }

        public async Task<ICollection<Exercise>> GetAll()
        {
            return await _ExerciseRepository.GetAll();
        }

        public Task<ICollection<Exercise>> GetExercisesBy(
                Expression<Func<Exercise,
                bool>> filter = null,
                Func<IQueryable<Exercise>,
                ICollection<Exercise>> options = null,
                string includeProperties = null)
        {
            return _ExerciseRepository.GetExercisesBy(filter);
        }


        public async Task<Boolean> AddNewExercise(CreateExerciseRequest ExerciseRequest)
        {
            var newExercise = new Exercise();

            newExercise.ExerciseId = ExerciseRequest.ExerciseId;
            newExercise.ExerciseName = ExerciseRequest.ExerciseName;
            newExercise.Set = ExerciseRequest.Set;
            newExercise.BodyPart = ExerciseRequest.BodyPart;
            newExercise.Step = ExerciseRequest.Step;
            newExercise.Rep = ExerciseRequest.Rep;
            newExercise.CaloBurn = ExerciseRequest.CaloBurn;

            await _ExerciseRepository.AddAsync(newExercise);
            return true;
        }

        public async Task<Boolean> UpdateExercise(UpdateExerciseRequest ExerciseRequest)
        {
            var ExerciseUpdate = GetExerciseByID(ExerciseRequest.ExerciseId).Result;

            ExerciseUpdate.ExerciseName = ExerciseRequest.ExerciseName;
            ExerciseUpdate.Set = ExerciseRequest.Set;
            ExerciseUpdate.BodyPart = ExerciseRequest.BodyPart;
            ExerciseUpdate.Step = ExerciseRequest.Step;
            ExerciseUpdate.Rep = ExerciseRequest.Rep;
            ExerciseUpdate.CaloBurn = ExerciseRequest.CaloBurn;
            await _ExerciseRepository.UpdateAsync(ExerciseUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteExercise(Exercise ExerciseDelete)
        //{
        //    ExerciseDelete.Status = 0;
        //    await _ExerciseRepository.UpdateAsync(ExerciseDelete);
        //    return true;
        //}

        public async Task<Exercise> GetExerciseByID(string id)
        {
            return await _ExerciseRepository.GetFirstOrDefaultAsync(x => x.ExerciseId == id);
        }
    }
}
