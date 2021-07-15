using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;

namespace StoreUI
{
    public class OrderPlaceMenu : IMenu
    {
        private static Orders _order = new Orders();
        private static Customer _cust = new Customer();
        private static StoreFront _store = new StoreFront();
        private IOrderBL _orderBL;
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;


        public OrderPlaceMenu(IOrderBL p_orderBL, ICustomerBL p_custBL, IStoreFrontBL p_storeBL){
            _orderBL = p_orderBL;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
        }

        public MenuType choice()
        {
            string input = Console.ReadLine();


            switch (input)
            {
                case "0":
                    _order = new Orders();
                    _cust = new Customer("", "", "", 0);
                    _store = new StoreFront();
                    return MenuType.OrderMenu;
                case "1":
                    StoreFront tempStore = SearchFunctions.SelectStoreFront(_storeBL);
                    if(tempStore != null){_store = tempStore;}
                    return MenuType.OrderPlaceMenu;
                case "2":
                    Customer tempCust = SearchFunctions.SelectCustomer(_custBL);
                    if (tempCust !=null){_cust = tempCust;}
                    return MenuType.OrderPlaceMenu;
                case "3":
                    if(_store.Name == ""){
                        return MenuType.Invalid;
                    }
                    LineItems tempItem = AddItem();
                    if(tempItem != null){
                        _order.OrderItems.Add(tempItem);
                        _order.Price += (tempItem.Product.Price*tempItem.Quantity);
                    }
                    return MenuType.OrderPlaceMenu;
                case "4":
                    if(_order.OrderItems.Count == 0 || _cust.Name == ""){return MenuType.Invalid;}
                    _order = _orderBL.PlaceOrder(_order, _cust, _store);
                    _storeBL.Update(_store);
                    Console.Clear();
                    System.Console.WriteLine("Order placed successfully");
                    System.Console.WriteLine($"Details: \nCustomer: {_cust.Name}");
                    System.Console.WriteLine(_order);
                    System.Console.WriteLine("\nPress Enter to return");
                    Console.ReadLine();
                    _order = new Orders();
                    _cust = new Customer("", "", "", 0);
                    _store = new StoreFront();
                    return MenuType.OrderMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---Place an order--->");
            if(_order.OrderItems.Count > 0){
                System.Console.WriteLine("Items: ");
                foreach (LineItems i in _order.OrderItems)
                {
                    System.Console.WriteLine($"Item: {i.Product.Name}, Quantity: {i.Quantity}, Price: {i.Quantity*i.Product.Price}");
                }
                System.Console.WriteLine($"Total Price: {_order.Price}\n");
            }
            if(_order.OrderItems.Count > 0 && _cust.Name != ""){
                System.Console.WriteLine("[4] Complete Order");
            }
            if(_store.Name != ""){
                System.Console.WriteLine("[3] Add items to order");
            }
            System.Console.WriteLine("[2] Select customer: "+_cust.Name);
            System.Console.WriteLine("[1] Select a store: "+_store.Name);
            System.Console.WriteLine("[0] Cancel");
        }

        private LineItems AddItem(){
            Console.Clear();
            if(_store.Inventory.Count == 0){
                System.Console.WriteLine("Store has no inventory");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return null;
            }
            System.Console.WriteLine("Select an item to add");
            for(int i = 0; i < _store.Inventory.Count; i++){
                System.Console.WriteLine($"\n[{i}]\n{_store.Inventory[i]}");
            }
            int num = Convert.ToInt32(Console.ReadLine());
            LineItems item = new LineItems();
            try
            {
                item.Product = _store.Inventory[num].Product;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Invalid input");
                System.Console.WriteLine("Press Enter to contine");
                Console.ReadLine();
                return null;
            }
            System.Console.WriteLine($"How many would you like to add? ({_store.Inventory[num].Quantity} in stock)");
            int amount = Convert.ToInt32(Console.ReadLine());
            if(amount > _store.Inventory[num].Quantity || amount <= 0){
                System.Console.WriteLine("Invalid amount");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return null;
            }
            item.Quantity = amount;
            _store.Inventory[num].Quantity -= amount;
            return item;
        }
    }
}