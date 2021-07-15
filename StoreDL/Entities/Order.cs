using System;
using System.Collections.Generic;
using StoreModels;
using System.Linq;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreFrontId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Location {get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreFront StoreFront { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
