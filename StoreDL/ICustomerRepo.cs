using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{   
    /// <summary>
    /// Handles data logic for customer database
    /// </summary>
    public interface ICustomerRepo : IRepo<Customer>
    {
        /// <summary>
        /// Searches database for customers with matching names
        /// </summary>
        /// <param name="p_name">The name being seached for</param>
        /// <returns>Returns any customers who have the desired name</returns>
        public List<Customer> NameSearch(string p_name);
    }
}