using System;
using StoreBL;
using StoreModels;
using System.Collections.Generic;

namespace StoreUI
{
    public class CustomerSearchMenu : IMenu
    {
        private static List<Customer> _cust = new List<Customer>();
        private CustomerBL _custBL;

        public CustomerSearchMenu(CustomerBL p_custBL){
            _custBL = p_custBL;
        }

        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    System.Console.WriteLine("Please enter customer name:");
                    try
                    {
                        _cust = _custBL.NameSearch(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
    
                    }

                    if(_cust.Count == 0){
                        System.Console.WriteLine("No customers were found by that name");
                        System.Console.WriteLine("Press Enter to return");
                        Console.ReadLine();
                        return MenuType.CustomerSearchMenu;
                    }

                    System.Console.WriteLine("<---Data Found--->");
                    foreach(Customer c in _cust){
                        System.Console.WriteLine("====================");
                        System.Console.WriteLine(c);
                        System.Console.WriteLine("====================");
                    }
                    System.Console.WriteLine("Press enter to return");
                    Console.ReadLine();
                    return MenuType.CustomerSearchMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---Customer Search--->");
            System.Console.WriteLine("[1] Search");
            System.Console.WriteLine("[0] Go back");
        }
    }
}