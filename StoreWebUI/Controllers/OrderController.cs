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
    public class OrderController : Controller
    {
        private ICustomerBL _custBL;
        private ILocationBL _locationBL;
        public static List<LineItemVM> _cart = new List<LineItemVM>();

        public OrderController(ICustomerBL p_custBL, ILocationBL p_locationBL)
        {
            _custBL = p_custBL;
            _locationBL = p_locationBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectCustomer()
        {
            return View(
                _custBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }

        public IActionResult SelectLocation(int p_id)
        {
            return View(
                _locationBL.GetAllLocations()
                .Select(store => new LocationVM(store))
                .ToList()
            );
        }

        public IActionResult AddItem(int p_id, int storeId)
        {
            return View(
                _locationBL.GetInventory(storeId)
                .Select(item => new LineItemVM(item))
                .ToList()
            );
        }
        
        [HttpPost]
        public IActionResult AddItem(int p_id, int storeId, LineItemVM lineItem)
        {
            _cart.Add(lineItem);
            return RedirectToAction("AddItem", "Order", new { p_id = p_id, storeId = storeId });
        }

        public IActionResult PlaceOrder(int p_id, int storeId)
        {
            return View(_cart);
        }

        public IActionResult ConfirmOrder(int p_id, int storeId)
        {
            Order ord = new Order();
            foreach(LineItemVM item in _cart)
            {
                ord.OrderItems.Add(
                    new LineItem
                    {
                        Product = _locationBL.GetProduct(item.ProductId),
                        Quantity = item.Quantity,
                        LocationId = null
                    }
                );
                ord.Price += item.Quantity * item.Price;
            }
            Location loc = _locationBL.GetById(storeId);
            Customer cust = _custBL.GetById(p_id);
            cust.Orders.Add(ord);
            loc.Orders.Add(ord);
            _custBL.Update(cust);
            _locationBL.Update(loc);
            return View();
        }
    }
}
