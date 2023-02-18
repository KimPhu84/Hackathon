using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleModule.Interface;
using BodyBuilderApp.Modules.ScheduleModule.Request;

namespace BodyBuilderApp.Modules.ScheduleModule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _ScheduleRepository;
        public ScheduleService(IScheduleRepository ScheduleRepository)
        {
            _ScheduleRepository = ScheduleRepository;
        }

        public async Task<ICollection<Schedule>> GetAll()
        {
            return await _ScheduleRepository.GetAll();
        }

        public Task<ICollection<Schedule>> GetSchedulesBy(
                Expression<Func<Schedule,
                bool>> filter = null,
                Func<IQueryable<Schedule>,
                ICollection<Schedule>> options = null,
                string includeProperties = null)
        {
            return _ScheduleRepository.GetSchedulesBy(filter);
        }


        public async Task<Boolean> AddNewSchedule(CreateScheduleRequest ScheduleRequest)
        {
            var newSchedule = new Schedule();

            newSchedule.ScheduleId = ScheduleRequest.ScheduleId;
            newSchedule.StartDate = ScheduleRequest.StartDate;
            newSchedule.EndDate = ScheduleRequest.EndDate;
            newSchedule.Status = ScheduleRequest.Status;
            newSchedule.TrainerId = ScheduleRequest.TrainerId;

            await _ScheduleRepository.AddAsync(newSchedule);
            return true;
        }

        public async Task<Boolean> UpdateSchedule(UpdateScheduleRequest ScheduleRequest)
        {
            var ScheduleUpdate = GetScheduleByID(ScheduleRequest.ScheduleId).Result;

            ScheduleUpdate.StartDate = ScheduleRequest.StartDate;
            ScheduleUpdate.EndDate = ScheduleRequest.EndDate;
            ScheduleUpdate.Status = ScheduleRequest.Status;
            ScheduleUpdate.TrainerId = ScheduleRequest.TrainerId;
            await _ScheduleRepository.UpdateAsync(ScheduleUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteSchedule(Schedule ScheduleDelete)
        //{
        //    ScheduleDelete.Status = 0;
        //    await _ScheduleRepository.UpdateAsync(ScheduleDelete);
        //    return true;
        //}

        public async Task<Schedule> GetScheduleByID(string id)
        {
            return await _ScheduleRepository.GetFirstOrDefaultAsync(x => x.ScheduleId == id);
        }
    }
}
