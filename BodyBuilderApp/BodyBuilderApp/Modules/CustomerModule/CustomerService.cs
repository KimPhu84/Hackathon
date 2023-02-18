using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.Repository;
using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.CustomerModule.Interface;
using BodyBuilderApp.Modules.CustomerModule.Request;
using System.Security.Cryptography.X509Certificates;

namespace BodyBuilderApp.Modules.CustomerModule
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _CustomerRepository.GetAll();
        }

        public Task<ICollection<Customer>> GetCustomersBy(
                Expression<Func<Customer,
                bool>> filter = null,
                Func<IQueryable<Customer>,
                ICollection<Customer>> options = null,
                string includeProperties = null)
        {
            return _CustomerRepository.GetCustomersBy(filter);
        }
        public async Task<Customer> GetCustomerByEmail(string email, string password)
        {
            return await _CustomerRepository.GetFirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
        public async Task<Customer> AuthencationAsync(string email, string password)
        {
           var user = await _CustomerRepository.GetFirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }
        public async Task<Boolean> AddNewCustomer(CreateCustomerRequest CustomerRequest)
        {
            var newCustomer = new Customer();

            newCustomer.UserId = CustomerRequest.UserId;
            newCustomer.Name = CustomerRequest.Name;
            newCustomer.Password = CustomerRequest.Password;
            newCustomer.Email = CustomerRequest.Email;
            newCustomer.Phone = CustomerRequest.UserId;
            newCustomer.Gender = CustomerRequest.Gender;
            newCustomer.Address = CustomerRequest.Address;
            newCustomer.Role = CustomerRequest.Role;
            newCustomer.TargetId = CustomerRequest.TargetId; 
            newCustomer.BodyStatusId= CustomerRequest.BodyStatusId;

            await _CustomerRepository.AddAsync(newCustomer);
            return true;
        }

        public async Task<Boolean> UpdateCustomer(UpdateCustomerRequest CustomerRequest)
        {
            var CustomerUpdate = GetCustomerByID(CustomerRequest.UserId).Result;
            CustomerUpdate.Name = CustomerRequest.Name;
            CustomerUpdate.Password = CustomerRequest.Password;
            CustomerUpdate.Email = CustomerRequest.Email;
            CustomerUpdate.Phone = CustomerRequest.UserId;
            CustomerUpdate.Gender = CustomerRequest.Gender;
            CustomerUpdate.Address = CustomerRequest.Address;
            CustomerUpdate.Role = CustomerRequest.Role;
            CustomerUpdate.TargetId = CustomerRequest.TargetId;
            CustomerUpdate.BodyStatusId = CustomerRequest.BodyStatusId;
            await _CustomerRepository.UpdateAsync(CustomerUpdate);
            return true;
        }

        //public async Task<Boolean> DeleteCustomer(Customer CustomerDelete)
        //{
        //    CustomerDelete.Status = 0;
        //    await _CustomerRepository.UpdateAsync(CustomerDelete);
        //    return true;
        //}

        public async Task<Customer> GetCustomerByID(string id)
        {
            return await _CustomerRepository.GetFirstOrDefaultAsync(filter: x => x.UserId == id,includeProperties: "BodyStatuses,Target");
        }
    }
}
