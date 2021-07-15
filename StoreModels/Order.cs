using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Order{

        public Order(){
            Price = 0;
            Location = new Location();
            OrderItems = new List<LineItem>();
        }

        public int OrderId{get; set;}
        public List<LineItem> OrderItems{get; set;}
        public Location Location{get; set;}
        public double Price{get; set;}

        public override string ToString()
        {
            string retString = $"Ordered from: {Location}\nItems :\n";
            foreach (LineItem i in OrderItems)
            {
                retString = String.Concat(retString, $"\n{i}\n");
            }
            retString = String.Concat(retString, $"\nTotal Price: ${Price}");
            return retString;
        }
    }
}