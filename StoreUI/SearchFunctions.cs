using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;

namespace StoreUI
{
    public static class SearchFunctions{
        public static Customer SelectCustomer(ICustomerBL p_custBL){
            Console.Clear();
            System.Console.WriteLine("Please enter the customer's name");
            string input = Console.ReadLine();
            List<Customer> custList = p_custBL.NameSearch(input);
            if(custList.Count == 0){
                System.Console.WriteLine("No customers were found by that name");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return null;
            }
            else if(custList.Count == 1){
                System.Console.WriteLine("Customer found");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return custList[0];
            }
            System.Console.WriteLine("Multiple customers found");
            System.Console.WriteLine("Please select the correct customer");
            for(int i = 0; i < custList.Count; i++){
                System.Console.WriteLine($"\n[{i}]\nName: {custList[i].Name}\nEmail: {custList[i].Email}");
            }
            int num = Convert.ToInt32(Console.ReadLine());
            try
            {
                return custList[num];
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Invalid selection");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return null;
            }
        }

        public static StoreFront SelectStoreFront(IStoreFrontBL p_storeBL){
            System.Console.WriteLine("Please enter the name of the store");
            string input = Console.ReadLine();
            List<StoreFront> storeList = p_storeBL.NameSearch(input);
            if(storeList.Count == 0){
                System.Console.WriteLine("No stores were found by that name");
                System.Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                return null;
            }
            else if(storeList.Count == 1){
                System.Console.WriteLine("Store found");
                System.Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return storeList[0];
            }
            System.Console.WriteLine("Multiple stores found");
            System.Console.WriteLine("Please select the correct store");
            for(int i = 0; i < storeList.Count; i++){
                System.Console.WriteLine($"\n[{i}]\nName: {storeList[i].Name}\nAddress: {storeList[i].Address}");
            }
            int num = Convert.ToInt32(Console.ReadLine());
            try
            {
                return storeList[num];
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Invalid selection");
                System.Console.WriteLine("Press Enter to continue");
                return null;
            }
        }
    }
}