namespace StoreUI
{
    public enum MenuType{
        MainMenu,
        CustomerMenu,
        CustomerAddMenu,
        CustomerShowMenu,
        CustomerSearchMenu,
        StoreFrontMenu,
        StoreFrontInventoryMenu,
        StoreFrontInventoryReplenishMenu,
        OrderMenu,
        OrderPlaceMenu,
        OrderGetMenu,
        Exit,
        Invalid,
        Unfinished
    }

    public interface IMenu{
        /// <summary>
        /// Shows the menu and the choices you can make.
        /// </summary>
        void dispMenu();

        /// <summary>
        /// Records user's input and selects menu option based on it
        /// </summary>
        /// <returns>Returns MenuType value corresponding to the user's selection
        MenuType choice();
    }
}