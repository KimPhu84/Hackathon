using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.ScheduleModule.Interface
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        public Task<ICollection<Schedule>> GetSchedulesBy(
             Expression<Func<Schedule, bool>> filter = null,
             Func<IQueryable<Schedule>, ICollection<Schedule>> options = null,
             string includeProperties = null
         );
    }
}
