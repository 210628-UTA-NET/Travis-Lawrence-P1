using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{   
    /// <summary>
    /// Handles Customer data logic for the database
    /// </summary>
    public interface ICustomerRepo
    {
        /// <summary>
        /// Adds a new Customer to the database
        /// </summary>
        /// <param name="p_cust">The Customer to be added</param>
        /// <returns>Returns the added Customer</returns>
        Customer AddCustomer(Customer p_cust);
        /// <summary>
        /// Retrieves all Customers from the database
        /// </summary>
        /// <returns>Returns a list of the Customers</returns>
        List<Customer> GetAllCustomers();
        /// <summary>
        /// Searches database for Customers with matching names
        /// </summary>
        /// <param name="p_name">The name being seached for</param>
        /// <returns>Returns any Customers who have the desired name</returns>
        List<Customer> NameSearch(string p_name);
        /// <summary>
        /// Updates a customer in the database
        /// </summary>
        /// <param name="p_cust">The customre to be updated, including its changes</param>
        /// <returns>Returns the updated customer</returns>
        Customer Update(Customer p_cust);
        Customer GetById(int p_id);
    }
}