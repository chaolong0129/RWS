using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            var strToCache = "Hello from cache";
            var absoluteExpiration = DateTime.Now.AddDays(1);
            var expirationFromNow = DateTime.UtcNow.AddDays(1);

            _cache.Set<string>("str", strToCache);
            _cache.Set<string>("str", strToCache, absoluteExpiration);
            _cache.Set<string>("str", strToCache, expirationFromNow);

            var listColors = new List<string> {
                "green", "white", "black"
            };

            _cache.Set<List<string>>("listColors", listColors);

            return View();
        }

        public IActionResult TryShowCachedData()
        {
            var str1 = _cache.Get<string>("str");

           var listColors = _cache.Get<List<string>>("listColors");

            List<string> listStrings = null;
            bool dataExist = _cache.TryGetValue<List<string>>("listColors", out listStrings);
            if (!dataExist)
                listStrings = new List<string>();
            return View(listStrings);
        }
    }
}