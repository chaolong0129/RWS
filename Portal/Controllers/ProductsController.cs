using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string lang, string category, string subcategory, Guid id)
        {
            return View();
        }

        public async Task<IActionResult> DetailsAsync(string lang, string category, string subcategory, Guid id)
        {

            return View();
        }

    }
}