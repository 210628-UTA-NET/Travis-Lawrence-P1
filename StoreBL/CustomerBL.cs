using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepo _repo;
        public CustomerBL(ICustomerRepo p_repo){
            _repo = p_repo;
        }

        public Customer AddCustomer(Customer p_entry)
        {
            return _repo.AddCustomer(p_entry);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public List<Customer> NameSearch(string p_name){
            return _repo.NameSearch(p_name);
        }

        public Customer Update(Customer p_cust)
        {
            return _repo.Update(p_cust);
        }

        public Customer GetById(int p_id)
        {
            return _repo.GetById(p_id);
        }
    }
}