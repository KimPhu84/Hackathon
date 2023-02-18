using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;

namespace BodyBuilderApp.Modules.BodyStatusModule.Interface
{
    public interface IBodyStatusRepository : IRepository<BodyStatus>
    {
        public Task<ICollection<BodyStatus>> GetBodyStatussBy(
             Expression<Func<BodyStatus, bool>> filter = null,
             Func<IQueryable<BodyStatus>, ICollection<BodyStatus>> options = null,
             string includeProperties = null
         );
    }
}
