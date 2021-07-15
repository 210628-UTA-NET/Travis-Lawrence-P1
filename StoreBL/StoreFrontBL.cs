using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontRepo _storeFrontRepo;
        
        public StoreFrontBL(IStoreFrontRepo p_storeFrontRepo){
            _storeFrontRepo = p_storeFrontRepo;
        }

        public List<StoreFront> NameSearch(string p_name)
        {
            return _storeFrontRepo.NameSearch(p_name);
        }

        public bool Update(StoreFront p_store)
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