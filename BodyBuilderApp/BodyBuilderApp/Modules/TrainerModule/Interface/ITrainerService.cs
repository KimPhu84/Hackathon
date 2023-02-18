using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TrainerModule.Request;

namespace BodyBuilderApp.Modules.TrainerModule.Interface
{
    public interface ITrainerService
    {
        public Task<ICollection<Trainer>> GetTrainersBy(
            Expression<Func<Trainer, bool>> filter = null,
            Func<IQueryable<Trainer>, ICollection<Trainer>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewTrainer(CreateTrainerRequest TrainerCreate);

        public Task<Boolean> UpdateTrainer(UpdateTrainerRequest TrainerUpdate);

        //public Task<Boolean> DeleteTrainer(Trainer TrainerDelete);

        public Task<ICollection<Trainer>> GetAll();

        public Task<Trainer> GetTrainerByID(string id);
    }
}
