using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.BodyStatusModule.Interface;
using BodyBuilderApp.Modules.BodyStatusModule.Request;

namespace BodyBuilderApp.Modules.BodyStatusModule
{
    public class BodyStatusService : IBodyStatusService
    {
        private readonly IBodyStatusRepository _BodyStatusRepository;
        public BodyStatusService(IBodyStatusRepository BodyStatusRepository)
        {
            _BodyStatusRepository = BodyStatusRepository;
        }

        public async Task<ICollection<BodyStatus>> GetAll()
        {
            return await _BodyStatusRepository.GetAll();
        }

        public Task<ICollection<BodyStatus>> GetBodyStatussBy(
                Expression<Func<BodyStatus,
                bool>> filter = null,
                Func<IQueryable<BodyStatus>,
                ICollection<BodyStatus>> options = null,
                string includeProperties = null)
        {
            return _BodyStatusRepository.GetBodyStatussBy(filter);
        }


        public async Task<Boolean> AddNewBodyStatus(CreateBodyStatusRequest BodyStatusRequest)
        {
            var newBodyStatus = new BodyStatus();

            newBodyStatus.BodyStatusId = BodyStatusRequest.BodyStatusId;
            newBodyStatus.Weight = BodyStatusRequest.Weight;
            newBodyStatus.Height = BodyStatusRequest.Height;
            newBodyStatus.Date = BodyStatusRequest.Date;
            newBodyStatus.UserId = BodyStatusRequest.UserId;

            await _BodyStatusRepository.AddAsync(newBodyStatus);
            return true;
        }

        public async Task<Boolean> UpdateBodyStatus(UpdateBodyStatusRequest BodyStatusRequest)
        {
            var BodyStatusUpdate = GetBodyStatusByID(BodyStatusRequest.BodyStatusId).Result;

            BodyStatusUpdate.Weight = BodyStatusRequest.Weight;
            BodyStatusUpdate.Height = BodyStatusRequest.Height;
            BodyStatusUpdate.Date = BodyStatusRequest.Date;
            BodyStatusUpdate.UserId = BodyStatusRequest.UserId;
            await _BodyStatusRepository.UpdateAsync(BodyStatusUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteBodyStatus(BodyStatus BodyStatusDelete)
        //{
        //    BodyStatusDelete.Status = 0;
        //    await _BodyStatusRepository.UpdateAsync(BodyStatusDelete);
        //    return true;
        //}

        public async Task<BodyStatus> GetBodyStatusByID(string id)
        {
            return await _BodyStatusRepository.GetFirstOrDefaultAsync(x => x.BodyStatusId == id);
        }
    }
}
