using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private ILocationRepo _storeFrontRepo;
        
        public StoreFrontBL(ILocationRepo p_storeFrontRepo){
            _storeFrontRepo = p_storeFrontRepo;
        }

        public List<Location> NameSearch(string p_name)
        {
            return _storeFrontRepo.NameSearch(p_name);
        }

        public bool Update(Location p_store)
        {
            try
            {
                _storeFrontRepo.Update(p_store);
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}