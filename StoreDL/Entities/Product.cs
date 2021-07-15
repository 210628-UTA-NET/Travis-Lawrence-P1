using System;
using System.Collections.Generic;
using StoreModels;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

        public Products ToStoreModel(){
            return new Products(){
                ProductID = this.ProductId,
                Name = this.Name,
                Price = (double)this.Price,
                Desc = this.Description,
                Category = this.Category
            };
        }
    }
}
