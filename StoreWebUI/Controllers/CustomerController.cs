using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _custBL;
        
        public CustomerController(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _custBL.AddCustomer(new Customer
                        {
                            Name = custVM.Name,
                            Address = custVM.Address,
                            Email = custVM.Email,
                            PhoneNumber = custVM.PhoneNumber
                        }
                    );

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                return View();
            }

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string p_name)
        {
            try
            {
                return View(
                    _custBL.NameSearch(p_name)
                    .Select(cust => new CustomerVM(cust))
                    .ToList()
                );
            }
            catch (Exception)
            {

                return View(
                    _custBL.GetAllCustomers()
                    .Select(cust => new CustomerVM(cust))
                    .ToList()
                );
            }
        }
    }
}
