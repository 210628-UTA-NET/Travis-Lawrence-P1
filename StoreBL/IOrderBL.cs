using StoreModels;

namespace StoreBL
{
    /// <summary>
    /// Handles all buisiness logic for Orders models
    /// </summary>
    public interface IOrderBL{
        /// <summary>
        /// Constructs an Orders object and adds it to the database
        /// </summary>
        /// <param name="p_entry">The new Orders object to be added</param>
        /// <param name="p_cust">The customer that placed the order</param>
        /// <param name="p_store">The store at which the order was placed</param>
        /// <returns>Returns the assembled Orders object</returns>
        Orders PlaceOrder(Orders p_entry, Customer p_cust, StoreFront p_store);
    }
}