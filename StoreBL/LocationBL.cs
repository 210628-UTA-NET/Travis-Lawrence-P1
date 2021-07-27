using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationRepo _locationRepo;
        
        public LocationBL(ILocationRepo p_locationRepo){
            _locationRepo = p_locationRepo;
        }

        public List<Location> GetAllLocations()
        {
            return _locationRepo.GetAllLocations();
        }

        public List<LineItem> GetInventory(int p_locationId)
        {
            return _locationRepo.GetInventory(p_locationId);
        }

        public List<Location> NameSearch(string p_name)
        {
            return _locationRepo.NameSearch(p_name);
        }

        public bool Update(Location p_store)
        {
            try
            {
                _locationRepo.Update(p_store);
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Product GetProduct(int p_id)
        {
            return _locationRepo.GetProduct(p_id);
        }

        public Location GetById(int p_id)
        {
            return _locationRepo.GetById(p_id);
        }
    }
}