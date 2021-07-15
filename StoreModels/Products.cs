using System;

namespace StoreModels
{
    public class Products{
        public Products(){
            Name = "";
            Price = 0;
        }
        public Products(string p_name, double p_price){
            Name = p_name;
            Price = p_price;
        }
        public Products(string p_name, double p_price, string p_desc, string p_cat){
            Name = p_name;
            Price = p_price;
            Desc = p_desc;
            Category = p_cat;
        }

        public int ProductID{get; set;}
        public string Name{get; set;}
        public double Price{get; set;}
        public string Desc{get; set;}
        public string Category{get; set;}


        public override string ToString()
        {
            string retString = $"Product Name: {Name}\nPrice: ${Price}";
            if(Desc != null){
                retString = String.Concat(retString, $"\nDescription: {Desc}");
            }
            if(Category != null){
                retString = String.Concat(retString, $"\nCategory: {Category}");
            }
            return retString;
        }
    }
}