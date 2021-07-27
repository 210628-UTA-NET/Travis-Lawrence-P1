using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class LocationController : Controller
    {
        private ILocationBL _locationBL;

        public LocationController(ILocationBL p_locationBL)
        {
            _locationBL = p_locationBL;
        }

        public IActionResult Index()
        {
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
                    _locationBL.NameSearch(p_name)
                    .Select(loc => new LocationVM(loc))
                    .ToList()
                );
            }
            catch (Exception)
            {

                return View(
                    _locationBL.GetAllLocations()
                    .Select(loc => new LocationVM(loc))
                    .ToList()
                );
            }
        }

        public IActionResult SeeInventory(int p_locationId)
        {
            return View(
                _locationBL.GetInventory(p_locationId)
                .Select(item => new LineItemVM(item))
                .ToList()
            );
        }
    }
}
