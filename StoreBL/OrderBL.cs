using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepo _repo;

        public OrderBL(IOrderRepo p_repo){
            _repo = p_repo;
        }

        public Orders PlaceOrder(Orders p_entry, Customer p_cust, StoreFront p_store){
            p_entry.CustomerID = p_cust.CustomerID;
            p_entry.Location = p_store.Name;
            p_entry.StoreFrontID = p_store.StoreID;
            p_entry.Location = p_store.Name;
            _repo.AddData(p_entry);
            return p_entry;
        }
    }
}