using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TargetModule.Interface;
using BodyBuilderApp.Modules.TargetModule.Request;

namespace BodyBuilderApp.Modules.TargetModule
{
    public class TargetService : ITargetService
    {
        private readonly ITargetRepository _TargetRepository;
        public TargetService(ITargetRepository TargetRepository)
        {
            _TargetRepository = TargetRepository;
        }

        public async Task<ICollection<Target>> GetAll()
        {
            return await _TargetRepository.GetAll();
        }

        public Task<ICollection<Target>> GetTargetsBy(
                Expression<Func<Target,
                bool>> filter = null,
                Func<IQueryable<Target>,
                ICollection<Target>> options = null,
                string includeProperties = null)
        {
            return _TargetRepository.GetTargetsBy(filter);
        }


        public async Task<Boolean> AddNewTarget(CreateTargetRequest TargetRequest)
        {
            var newTarget = new Target();

            newTarget.TargetId = TargetRequest.TargetId;
            newTarget.TargetName = TargetRequest.TargetName;

            await _TargetRepository.AddAsync(newTarget);
            return true;
        }

        public async Task<Boolean> UpdateTarget(UpdateTargetRequest TargetRequest)
        {
            var TargetUpdate = GetTargetByID(TargetRequest.TargetId).Result;

            TargetUpdate.TargetName = TargetRequest.TargetName;
            await _TargetRepository.UpdateAsync(TargetUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteTarget(Target TargetDelete)
        //{
        //    TargetDelete.Status = 0;
        //    await _TargetRepository.UpdateAsync(TargetDelete);
        //    return true;
        //}

        public async Task<Target> GetTargetByID(string id)
        {
            return await _TargetRepository.GetFirstOrDefaultAsync(x => x.TargetId == id);
        }
    }
}
