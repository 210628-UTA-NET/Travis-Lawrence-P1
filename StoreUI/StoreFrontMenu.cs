using System;

namespace StoreUI
{
    public class StoreFrontMenu : IMenu
    {
        public MenuType choice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.StoreFrontInventoryMenu;
                default:
                    return MenuType.Invalid;
            }
        }

        public void dispMenu()
        {
            System.Console.WriteLine("<---Store Menu--->");
            System.Console.WriteLine("Please select an option");
            System.Console.WriteLine("[1] Go to Inventory Menu");
            System.Console.WriteLine("[0] Back to main menu");
        }
    }
}