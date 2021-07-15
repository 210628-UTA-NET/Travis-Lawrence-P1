using System;

namespace StoreModels
{
    public class LineItems{

        public LineItems(){
            Quantity = 0;
            Product = new Products();
        }
        public LineItems(int p_quan, Products p_prod){
            Quantity = p_quan;
            Product = p_prod;
        }

        public int LineItemId{get; set;}
        public int? StoreFrontID{get; set;}
        public int? OrderID{get; set;}
        public int ProductID{get; set;}
        public int Quantity{get; set;}
        public Products Product{get; set;}

        public override string ToString()
        {
            return $"{Product}\nQuantity: {Quantity}";
        }
    }
}