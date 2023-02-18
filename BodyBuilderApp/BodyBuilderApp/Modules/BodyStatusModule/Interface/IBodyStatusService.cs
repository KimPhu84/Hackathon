using Utils.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.BodyStatusModule.Request;

namespace BodyBuilderApp.Modules.BodyStatusModule.Interface
{
    public interface IBodyStatusService
    {
        public Task<ICollection<BodyStatus>> GetBodyStatussBy(
            Expression<Func<BodyStatus, bool>> filter = null,
            Func<IQueryable<BodyStatus>, ICollection<BodyStatus>> options = null,
            string includeProperties = null);

        public Task<Boolean> AddNewBodyStatus(CreateBodyStatusRequest BodyStatusCreate);

        public Task<Boolean> UpdateBodyStatus(UpdateBodyStatusRequest BodyStatusUpdate);

        //public Task<Boolean> DeleteBodyStatus(BodyStatus BodyStatusDelete);

        public Task<ICollection<BodyStatus>> GetAll();

        public Task<BodyStatus> GetBodyStatusByID(string id);
    }
}
