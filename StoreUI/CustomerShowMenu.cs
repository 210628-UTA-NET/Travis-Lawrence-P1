using System;
using System.Collections.Generic;
using StoreBL;
using StoreModels;

namespace StoreUI
{
    public class CustomerShowMenu : IMenu
    {
        private static List<Customer> _cust = new List<Customer>();
        private CustomerBL _custBL;

        public CustomerShowMenu(CustomerBL p_custBL){
            _custBL = p_custBL;
        }

        public MenuType choice()
        {
            Console.ReadLine();
            return MenuType.CustomerMenu;
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---Customer Info--->");
            _cust = _custBL.GetAllData();
            foreach(Customer c in _cust){
                System.Console.WriteLine("====================");
                System.Console.WriteLine(c);
                System.Console.WriteLine("====================");
            }
            System.Console.WriteLine("Press Enter to return");
        }
    }
}