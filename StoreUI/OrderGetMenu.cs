using System;
using StoreBL;
using StoreModels;
using System.Collections.Generic;

namespace StoreUI
{
    public class OrderGetMenu : IMenu
    {
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;

        public OrderGetMenu(ICustomerBL p_custBL, IStoreFrontBL p_storeBL){
            _custBL = p_custBL;
            _storeBL = p_storeBL;
        }

        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return MenuType.OrderMenu;
                case "1":
                    Customer cust = SearchFunctions.SelectCustomer(_custBL);
                    Console.Clear();
                    if(cust.Orders.Count == 0){
                        System.Console.WriteLine($"{cust.Name} has not placed any orders.");
                    }
                    else{
                        System.Console.WriteLine($"{cust.Name}'s Order History:\n");
                        foreach (Orders o in cust.Orders)
                        {
                            System.Console.WriteLine("--------------------");
                            System.Console.WriteLine(o);
                        };
                    }
                    System.Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.OrderMenu;
                case "2":
                    StoreFront store = SearchFunctions.SelectStoreFront(_storeBL);
                    Console.Clear();
                    if(store.Orders.Count == 0){
                        System.Console.WriteLine($"No orders have been placed at {store.Name}");
                    }
                    else{
                        System.Console.WriteLine($"Order history from {store.Name}:\n");
                        foreach (Orders o in store.Orders)
                        {
                            System.Console.WriteLine("--------------------");
                            System.Console.WriteLine(o);
                        };
                    }
                    System.Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.OrderMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---View Order History--->");
            System.Console.WriteLine("[2] Search by store");
            System.Console.WriteLine("[1] Search by customer");
            System.Console.WriteLine("[0] Go back");
        }
    }
}