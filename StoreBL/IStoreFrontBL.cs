using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    /// <summary>
    /// Handles the business logic for StoreFronts
    /// </summary>
    public interface IStoreFrontBL{
        /// <summary>
        /// Searches for all StoreFronts by a given name
        /// </summary>
        /// <param name="p_name">The name being searched for</param>
        /// <returns>Returns a list of all StoreFronts will matching names</returns>
        List<StoreFront> NameSearch(string p_name);
        /// <summary>
        /// Updates a StoreFront model in the database
        /// </summary>
        /// <param name="p_store">The StoreFront with modified data</param>
        /// <returns>Returns a boolean indicating whether the update was successful</returns>
        bool Update(StoreFront p_store);
    }
}