using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.CustomerModule.Interface;

namespace BodyBuilderAppApp.Modules.CustomerModule
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly BodyBuilderAppContext _db;

        public CustomerRepository(BodyBuilderAppContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ICollection<Customer>> GetCustomersBy(
            Expression<Func<Customer, bool>> filter = null,
            Func<IQueryable<Customer>, ICollection<Customer>> options = null,
            string includeProperties = null
        )
        {
            IQueryable<Customer> query = DbSet;

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
