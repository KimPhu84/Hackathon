using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TargetModule.Request;

namespace BodyBuilderApp.Modules.TargetModule.Interface
{
    public interface ITargetService
    {
        public Task<ICollection<Target>> GetTargetsBy(
            Expression<Func<Target, bool>> filter = null,
            Func<IQueryable<Target>, ICollection<Target>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewTarget(CreateTargetRequest TargetCreate);

        public Task<Boolean> UpdateTarget(UpdateTargetRequest TargetUpdate);

        //public Task<Boolean> DeleteTarget(Target TargetDelete);

        public Task<ICollection<Target>> GetAll();

        public Task<Target> GetTargetByID(string id);
    }
}
