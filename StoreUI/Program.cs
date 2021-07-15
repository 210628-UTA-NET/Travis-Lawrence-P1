using System;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new MainMenu();
            bool exit = false;
            MenuType currentMenu = MenuType.MainMenu;
            MenuFactory factory = new MenuFactory();

            while(!exit){
                Console.Clear();
                menu.dispMenu();
                currentMenu = menu.choice();

                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        menu = factory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        menu = factory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.CustomerAddMenu:
                        menu = factory.GetMenu(MenuType.CustomerAddMenu);
                        break;
                    case MenuType.CustomerShowMenu:
                        menu = factory.GetMenu(MenuType.CustomerShowMenu);
                        break;
                    case MenuType.CustomerSearchMenu:
                        menu = factory.GetMenu(MenuType.CustomerSearchMenu);
                        break;
                    case MenuType.StoreFrontMenu:
                        menu = factory.GetMenu(MenuType.StoreFrontMenu);
                        break;
                    case MenuType.StoreFrontInventoryMenu:
                        menu = factory.GetMenu(MenuType.StoreFrontInventoryMenu);
                        break;
                    case MenuType.StoreFrontInventoryReplenishMenu:
                        menu = factory.GetMenu(MenuType.StoreFrontInventoryReplenishMenu);
                        break;
                    case MenuType.OrderMenu:
                        menu = factory.GetMenu(MenuType.OrderMenu);
                        break;
                    case MenuType.OrderPlaceMenu:
                        menu = factory.GetMenu(MenuType.OrderPlaceMenu);
                        break;
                    case MenuType.OrderGetMenu:
                        menu = factory.GetMenu(MenuType.OrderGetMenu);
                        break;
                    case MenuType.Exit:
                        exit = true;
                        break;
                    case MenuType.Invalid:
                        System.Console.WriteLine("Error: input not recognized.");
                        System.Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case MenuType.Unfinished:
                        System.Console.WriteLine("Sorry, I'm still working on that one.");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
