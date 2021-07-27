using System;

namespace StoreModels
{
    public class LineItem{

        public LineItem(){
            Quantity = 0;
        }
        public LineItem(int p_quan, Product p_prod){
            Quantity = p_quan;
            Product = p_prod;
        }

        public int LineItemId{get; set;}
        public int Quantity{get; set;}
        public Product Product{get; set;}
        public int? LocationId{get; set;}

        public override string ToString()
        {
            return $"{Product}\nQuantity: {Quantity}";
        }
    }
}