using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        public IActionResult TrySession()
        {
            List<string> listColors = new List<string>
            {
                "green", "white", "black"
            };
            var listColorsBytes = ObjectToByteArray(listColors);
            HttpContext.Session.Set("listColors", listColorsBytes);
            return View();
        }

        public IActionResult Colors()
        {
            List<string> listColors = new List<string>();
            var listBytesColors = new Byte[1000];

            bool hasValue =
             HttpContext.Session.TryGetValue("listColors",
                                              out listBytesColors);
            if (hasValue)
                listColors =
                   (List<string>)ByteArrayToObject(listBytesColors);


            return View(listColors);
        }

        // Convert an object to a byte array 
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object 
        public Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}