using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Location{

        public Location(){
            Name = "";
            Address = "";
            Inventory = new List<LineItem>();
            Orders = new List<Order>();
        }
        public Location(string p_name, string p_addr, List<LineItem> p_inventory, List<Order> p_orders){
            Name = p_name;
            Address = p_addr;
            Inventory = p_inventory;
            Orders = p_orders;
        }

        public int LocationId{get; set;}
        public string Name{get; set;}
        public string Address{get; set;}
        public List<LineItem> Inventory{get; set;}
        public List<Order> Orders{get; set;}
    }
}