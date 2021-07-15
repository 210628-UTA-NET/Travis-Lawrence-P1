using System;

namespace StoreUI
{
    public class MainMenu : IMenu
    {
        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StoreFrontMenu;
                case "3":
                    return MenuType.OrderMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<===Main Menu===>");
            System.Console.WriteLine("Please select an option.");
            System.Console.WriteLine("[3] Order menu");
            System.Console.WriteLine("[2] Store menu");
            System.Console.WriteLine("[1] Customer menu");
            System.Console.WriteLine("[0] Exit");
        }
    }
}