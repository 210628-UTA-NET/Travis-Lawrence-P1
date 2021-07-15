using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class CustomerRepo : ICustomerRepo
    {
        private StoreDBContext _context;
        public CustomerRepo(StoreDBContext p_context){
            _context = p_context;
        }

        public Customer AddCustomer(Customer p_entry)
        {
            _context.Customers.Add(p_entry);
            _context.SaveChanges();
            return p_entry;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        public List<Customer> NameSearch(string p_name)
        {
            return GetAllCustomers().Where(c => c.Name == p_name).ToList();
        }
    }
}