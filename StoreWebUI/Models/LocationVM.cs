using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class LocationVM
    {
        public LocationVM() { }
        public LocationVM(Location p_location)
        {
            LocationId = p_location.LocationId;
            Name = p_location.Name;
            Address = p_location.Address;
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
