using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    /// <summary>
    /// Handles all business logic for Customer model
    /// </summary>
    public interface ICustomerBL{
        /// <summary>
        /// Retrieves all Customer data from the database
        /// </summary>
        /// <returns>Returns all Customer data found</returns>
        List<Customer> GetAllCustomers();
        /// <summary>
        /// Adds a new Customer to the database
        /// </summary>
        /// <param name="p_entry">The Customer object to be added</param>
        /// <returns>Returns the added Customer</returns>
        Customer AddCustomer(Customer p_entry);
        /// <summary>
        /// Searches for and returns a Customer based on their name
        /// </summary>
        /// <param name="p_name">The desired name</param>
        /// <returns>Returns all Customers with a matching name</returns>
        List<Customer> NameSearch(string p_name);
        /// <summary>
        /// Updates a customer in the database
        /// </summary>
        /// <param name="p_cust">The changed customer, including changes</param>
        /// <returns>Returns the changed customer</returns>
        Customer Update(Customer p_cust);
        Customer GetById(int p_id);
    }
}