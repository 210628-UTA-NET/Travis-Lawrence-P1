using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class StoreFront{

        public StoreFront(){
            Name = "";
            Address = "";
            Inventory = new List<LineItems>();
            Orders = new List<Orders>();
        }
        public StoreFront(string p_name, string p_addr, List<LineItems> p_inventory, List<Orders> p_orders){
            Name = p_name;
            Address = p_addr;
            Inventory = p_inventory;
            Orders = p_orders;
        }

        public int StoreID{get; set;}
        public string Name{get; set;}
        public string Address{get; set;}
        public List<LineItems> Inventory{get; set;}
        public List<Orders> Orders{get; set;}
    }
}