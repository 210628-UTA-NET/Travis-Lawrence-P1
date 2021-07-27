using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM() { }
        public LineItemVM(LineItem p_lI)
        {
            LineItemId = p_lI.LineItemId;
            Quantity = p_lI.Quantity;
            ProductId = p_lI.Product.ProductId;
            Name = p_lI.Product.Name;
            Price = p_lI.Product.Price;
            Desc = p_lI.Product.Desc;
            Category = p_lI.Product.Category;
        }

        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
    }
}
