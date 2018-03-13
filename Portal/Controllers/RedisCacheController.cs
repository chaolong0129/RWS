using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class RedisCacheController : Controller
    {
        private ICacheRedis cacheRedis;
        public RedisCacheController(ICacheRedis cacheRedis)
        {
            this.cacheRedis = cacheRedis;
        }

        public IActionResult Index()
        {
            List<string> listColors = new List<string>
             {"green", "white", "black" };
            this.cacheRedis.Set<List<string>>("listColors", listColors);
            return View();
        }

        public IActionResult ShowCacheData()
        {
            List<string> listColors = this.cacheRedis.Get<List<string>>("listColors");
            return View(listColors);
        }

    }
}