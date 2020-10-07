using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Route("")]
        public ViewResult Main()
        {
            HttpContext.Session.SetInt32("Counter", 0);
            ViewBag.Counter = HttpContext.Session.GetInt32("Counter");
            return View();
        }
        [HttpGet]
        [Route("Random")]
        public ViewResult Random()
        {
            int Temp = HttpContext.Session.GetInt32("Counter").Value + 1;
            HttpContext.Session.SetInt32("Counter", Temp);
            ViewBag.Counter = HttpContext.Session.GetInt32("Counter");

            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string FinalCode = new string(stringChars);
            ViewBag.Passcode = FinalCode;
            return View();
        }
    }
}
