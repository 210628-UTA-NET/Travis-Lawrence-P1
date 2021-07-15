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

        public Customer AddData(Customer p_entry)
        {
            return _repo.AddData(p_entry);
        }

        public List<Customer> GetAllData()
        {
            return _repo.GetAllData();
        }

        public List<Customer> NameSearch(string p_name){
            return _repo.NameSearch(p_name);
        }
    }
}