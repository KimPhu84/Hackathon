using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.TargetModule.Interface
{
    public interface ITargetRepository : IRepository<Target>
    {
        public Task<ICollection<Target>> GetTargetsBy(
             Expression<Func<Target, bool>> filter = null,
             Func<IQueryable<Target>, ICollection<Target>> options = null,
             string includeProperties = null
         );
    }
}
