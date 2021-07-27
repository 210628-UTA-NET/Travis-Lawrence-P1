using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {
            LocationId = 0;
            Price = 0;
            CustomerId = 0;
        }
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
    }
}
