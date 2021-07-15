using System;
using StoreModels;
using StoreBL;
using System.Threading;

namespace StoreUI
{
    public class CustomerAddMenu : IMenu
    {
        private static Customer _cust = new Customer();
        private ICustomerBL _custBL;
        public CustomerAddMenu(ICustomerBL p_custBL){
            _custBL = p_custBL;
        }
        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    _cust = new Customer("","","",0);
                    return MenuType.CustomerMenu;
                case "1":
                    if(_cust.Name == "" || _cust.Address == "" || _cust.Email == "" || _cust.PhoneNumber == 0){
                        System.Console.WriteLine("!!!Customer data cannot be blank.!!!");
                        Thread.Sleep(1000);
                        return MenuType.CustomerAddMenu;
                    }
                    _custBL.AddData(_cust);
                    System.Console.WriteLine("Customer added successfully.");
                    System.Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    _cust = new Customer("","","",0);
                    return MenuType.CustomerMenu;
                case "2":
                    try
                    {
                        _cust.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine("Phone number must be 10 digits.");
                        Thread.Sleep(1000);
                    }
                    return MenuType.CustomerAddMenu;
                case "3":
                    try
                    {
                        _cust.Email = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        System.Console.WriteLine("Email must contain an @");
                        Thread.Sleep(1000);
                    }
                    return MenuType.CustomerAddMenu;
                case "4":
                    _cust.Address = Console.ReadLine();
                    return MenuType.CustomerAddMenu;
                case "5":
                    _cust.Name = Console.ReadLine();
                    return MenuType.CustomerAddMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---New Customer--->");
            System.Console.WriteLine("[5] Edit Name: "+_cust.Name);
            System.Console.WriteLine("[4] Edit Address: "+_cust.Address);
            System.Console.WriteLine("[3] Edit Email: "+_cust.Email);
            System.Console.WriteLine("[2] Edit Phone Number: "+_cust.PhoneNumber);
            System.Console.WriteLine("[1] Done");
            System.Console.WriteLine("[0] Cancel");
        }
    }
}