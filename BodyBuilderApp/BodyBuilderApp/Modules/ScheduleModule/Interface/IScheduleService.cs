using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.ScheduleModule.Request;

namespace BodyBuilderApp.Modules.ScheduleModule.Interface
{
    public interface IScheduleService
    {
        public Task<ICollection<Schedule>> GetSchedulesBy(
            Expression<Func<Schedule, bool>> filter = null,
            Func<IQueryable<Schedule>, ICollection<Schedule>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewSchedule(CreateScheduleRequest ScheduleCreate);

        public Task<Boolean> UpdateSchedule(UpdateScheduleRequest ScheduleUpdate);

        //public Task<Boolean> DeleteSchedule(Schedule ScheduleDelete);

        public Task<ICollection<Schedule>> GetAll();

        public Task<Schedule> GetScheduleByID(string id);
    }
}
