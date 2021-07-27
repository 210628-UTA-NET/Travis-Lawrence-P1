using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    /// <summary>
    /// Handles the business logic for StoreFronts
    /// </summary>
    public interface ILocationBL{
        /// <summary>
        /// Searches for all StoreFronts by a given name
        /// </summary>
        /// <param name="p_name">The name being searched for</param>
        /// <returns>Returns a list of all StoreFronts will matching names</returns>
        List<Location> NameSearch(string p_name);
        /// <summary>
        /// Updates a StoreFront model in the database
        /// </summary>
        /// <param name="p_store">The StoreFront with modified data</param>
        /// <returns>Returns a boolean indicating whether the update was successful</returns>
        bool Update(Location p_store);
        /// <summary>
        /// Returns all Locations in the database
        /// </summary>
        /// <returns>Returns a list of the locations</returns>
        List<Location> GetAllLocations();
        /// <summary>
        /// Returns a store's current inventory
        /// </summary>
        /// <param name="p_locationId">The Id of the store</param>
        /// <returns>Returns the inventory in list form</returns>
        List<LineItem> GetInventory(int p_locationId);
        Product GetProduct(int p_id);
        Location GetById(int p_id);
    }
}