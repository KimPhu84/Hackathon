using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.TrainerModule.Interface;

namespace BodyBuilderAppApp.Modules.TrainerModule
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        private readonly BodyBuilderAppContext _db;

        public TrainerRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<Trainer>> GetTrainersBy(
            Expression<Func<Trainer, bool>> filter = null,
            Func<IQueryable<Trainer>, ICollection<Trainer>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Trainer> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return options != null ? options(query).ToList() : await query.ToListAsync();
        }
    }
}
