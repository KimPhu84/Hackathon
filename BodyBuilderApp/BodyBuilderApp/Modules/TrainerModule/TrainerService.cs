using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TrainerModule.Interface;
using BodyBuilderApp.Modules.TrainerModule.Request;

namespace BodyBuilderApp.Modules.TrainerModule
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _TrainerRepository;
        public TrainerService(ITrainerRepository TrainerRepository)
        {
            _TrainerRepository = TrainerRepository;
        }

        public async Task<ICollection<Trainer>> GetAll()
        {
            return await _TrainerRepository.GetAll();
        }

        public Task<ICollection<Trainer>> GetTrainersBy(
                Expression<Func<Trainer,
                bool>> filter = null,
                Func<IQueryable<Trainer>,
                ICollection<Trainer>> options = null,
                string includeProperties = null)
        {
            return _TrainerRepository.GetTrainersBy(filter);
        }


        public async Task<Boolean> AddNewTrainer(CreateTrainerRequest TrainerRequest)
        {
            var newTrainer = new Trainer();

            newTrainer.TrainerId = TrainerRequest.TrainerId;
            newTrainer.Name = TrainerRequest.Name;
            newTrainer.Phone= TrainerRequest.Phone;
            newTrainer.Password = TrainerRequest.Password;
            newTrainer.Role = TrainerRequest.Role;
            newTrainer.Status = TrainerRequest.Status; 
            await _TrainerRepository.AddAsync(newTrainer);
            return true;
        }

        public async Task<Boolean> UpdateTrainer(UpdateTrainerRequest TrainerRequest)
        {
            var TrainerUpdate = GetTrainerByID(TrainerRequest.TrainerId).Result;

            TrainerUpdate.TrainerId = TrainerRequest.TrainerId;
            TrainerUpdate.Name = TrainerRequest.Name;
            TrainerUpdate.Phone = TrainerRequest.Phone;
            TrainerUpdate.Password = TrainerRequest.Password;
            TrainerUpdate.Role = TrainerRequest.Role;
            TrainerUpdate.Status = TrainerRequest.Status;
            await _TrainerRepository.UpdateAsync(TrainerUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteTrainer(Trainer TrainerDelete)
        //{
        //    TrainerDelete.Status = 0;
        //    await _TrainerRepository.UpdateAsync(TrainerDelete);
        //    return true;
        //}

        public async Task<Trainer> GetTrainerByID(string id)
        {
            return await _TrainerRepository.GetFirstOrDefaultAsync(x => x.TrainerId == id);
        }
    }
}
