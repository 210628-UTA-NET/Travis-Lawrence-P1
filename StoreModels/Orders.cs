using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Orders{

        public Orders(){
            Price = 0;
            Location = "";
            OrderItems = new List<LineItems>();
        }

        public Orders(string s){
            Location = s;
            OrderItems = new List<LineItems>();
            Price = 0;
        }

        public int OrderID{get; set;}
        public int? CustomerID{get; set;}
        public int? StoreFrontID{get; set;}
        public List<LineItems> OrderItems{get; set;}
        public string Location{get; set;}
        public double Price{get; set;}

        public override string ToString()
        {
            string retString = $"Ordered from: {Location}\nItems :\n";
            foreach (LineItems i in OrderItems)
            {
                retString = String.Concat(retString, $"\n{i}\n");
            }
            retString = String.Concat(retString, $"\nTotal Price: ${Price}");
            return retString;
        }
    }
}