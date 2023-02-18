using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.TrainerModule.Interface
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        public Task<ICollection<Trainer>> GetTrainersBy(
             Expression<Func<Trainer, bool>> filter = null,
             Func<IQueryable<Trainer>, ICollection<Trainer>> options = null,
             string includeProperties = null
         );
    }
}
