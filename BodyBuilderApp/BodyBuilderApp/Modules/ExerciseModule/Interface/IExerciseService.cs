using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ExerciseModule.Request;

namespace BodyBuilderApp.Modules.ExerciseModule.Interface
{
    public interface IExerciseService
    {
        public Task<ICollection<Exercise>> GetExercisesBy(
            Expression<Func<Exercise, bool>> filter = null,
            Func<IQueryable<Exercise>, ICollection<Exercise>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewExercise(CreateExerciseRequest ExerciseCreate);

        public Task<Boolean> UpdateExercise(UpdateExerciseRequest ExerciseUpdate);

        //public Task<Boolean> DeleteExercise(Exercise ExerciseDelete);

        public Task<ICollection<Exercise>> GetAll();

        public Task<Exercise> GetExerciseByID(string id);
    }
}
