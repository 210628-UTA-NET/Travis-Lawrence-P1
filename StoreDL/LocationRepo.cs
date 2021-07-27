using System.Collections.Generic;
using StoreModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class LocationRepo : ILocationRepo
    {
        private StoreDBContext _context;

        public LocationRepo(StoreDBContext p_context){
            _context = p_context;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.Select(loc => loc).ToList();
        }

        public List<LineItem> GetInventory(int p_locationId)
        {
            return _context.LineItems.Include(line => line.Product).Where(line => line.LocationId == p_locationId).ToList();
        }

        public List<Location> NameSearch(string p_name)
        {
            return GetAllLocations().Where(s => s.Name == p_name).ToList();
        }

        public Location Update(Location p_store){
            _context.Update(p_store);
            _context.SaveChanges();
            return p_store;
        }

        public Product GetProduct(int p_id)
        {
            return _context.Products.Find(p_id);
        }

        public Location GetById(int p_id)
        {
            return _context.Locations.Find(p_id);
        }
    }
}