using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{   
    /// <summary>
    /// Handles data logic for StoreFront database
    /// </summary>
    public interface IStoreFrontRepo : IRepo<StoreFront>{
        /// <summary>
        /// Searches database for storefronts with names identical to input
        /// </summary>
        /// <param name="p_name">The name being searched for</param>
        /// <returns>Returns a list of all storefronts with the desired name</returns>
        List<StoreFront> NameSearch(string p_name);
        bool Update(StoreFront p_store);
    }
}