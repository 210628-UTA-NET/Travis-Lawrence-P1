using System;
using StoreBL;
using StoreModels;

namespace StoreUI
{
    public class StoreFrontInventoryReplenishMenu : IMenu
    {
        private IStoreFrontBL _storeBL;

        public StoreFrontInventoryReplenishMenu(IStoreFrontBL p_storeBL){
            _storeBL = p_storeBL;

        }
        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return MenuType.StoreFrontInventoryMenu;
                case "1":
                    StoreFront store = SearchFunctions.SelectStoreFront(_storeBL);
                    Console.Clear();
                    if(store.Inventory.Count == 0){
                        System.Console.WriteLine("Store has no inventory");
                    }
                    else{
                        for(int i = 0; i < store.Inventory.Count; i++){
                            System.Console.WriteLine("Please select the item to restock");
                            System.Console.WriteLine($"[{i}]");
                            System.Console.WriteLine(store.Inventory[i]);
                        }
                        int num = Convert.ToInt32(Console.ReadLine());
                        if(num < 0 || num >= store.Inventory.Count){
                            System.Console.WriteLine("Invalid input");
                            System.Console.WriteLine("Press Enter to return");
                            Console.ReadLine();
                            return MenuType.StoreFrontInventoryMenu;
                        }
                        System.Console.WriteLine("How many would you like to restock?");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        if(quantity < 0){
                            System.Console.WriteLine("Quantity cannot be a negative number");
                            System.Console.WriteLine("Press Enter to return");
                            Console.ReadLine();
                            return MenuType.StoreFrontInventoryMenu;
                        }
                        store.Inventory[num].Quantity += quantity;
                        _storeBL.Update(store);
                        System.Console.WriteLine("Inventory successfully restocked");
                        System.Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                    }
                    return MenuType.StoreFrontInventoryMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---Restock Inventory--->");
            System.Console.WriteLine("[1] Find store");
            System.Console.WriteLine("[0] Back");
        }
    }
}