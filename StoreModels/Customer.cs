using System;
using System.Collections.Generic;

namespace StoreModels
{

    //To do: regex phone number for proper format
    public class Customer{

        public Customer()
        {
            Name = "";
            Address = "";
            Email = "";
            PhoneNumber = 0;
        }

        public Customer(string p_name, string p_address, string p_email, long p_phone){
            Name = p_name;
            Address = p_address;
            Email = p_email;
            PhoneNumber = p_phone;
        }

        public int CustomerID{get; set;}
        public string Name{get; set;}
        public string Address{get; set;}
        public string Email{get; set;}
        public long PhoneNumber{get; set;}

        public List<Orders> Orders{get; set;}

        public override string ToString()
        {
            return $"Name: {Name}\n Address: {Address}\n Email: {Email}\n Phone Number: {PhoneNumber}";
        }
    }

}