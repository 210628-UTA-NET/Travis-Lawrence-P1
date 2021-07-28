using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{   
    /// <summary>
    /// Handles data logic for Location database
    /// </summary>
    public interface ILocationRepo{
        /// <summary>
        /// Retrieves all Locations from the database
        /// </summary>
        /// <returns>Returns a list of the retrieved Locations</returns>
        List<Location> GetAllLocations();
        /// <summary>
        /// Searches database for Locations with names identical to input
        /// </summary>
        /// <param name="p_name">The name being searched for</param>
        /// <returns>Returns a list of all Locations with the desired name</returns>
        List<Location> NameSearch(string p_name);
        /// <summary>
        /// Updates a given Location's data in the database
        /// </summary>
        /// <param name="p_store">The Location that should be updated</param>
        /// <returns>Returns the entered Location</returns>
        Location Update(Location p_store);
        /// <summary>
        /// Gets a location's current inventory
        /// </summary>
        /// <param name="p_locationId">The id of the store</param>
        /// <returns>Returns the inventory in list form</returns>
        List<LineItem> GetInventory(int p_locationId);
        Product GetProduct(int p_id);
        Location GetById(int p_id);
        List<Order> GetOrders(int p_id);
    }
}