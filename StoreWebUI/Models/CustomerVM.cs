using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM() { }
        public CustomerVM(Customer p_cust)
        {
            Id = p_cust.CustomerId;
            Name = p_cust.Name;
            Address = p_cust.Address;
            Email = p_cust.Email;
            PhoneNumber = p_cust.PhoneNumber;
        }

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public long PhoneNumber { get; set; }
    }
}
