using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperTest.Models;


namespace DapperTest.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly UserFactory _userFactory;

        public HomeController(UserFactory uFactory)
        {
            _userFactory = uFactory;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Users()
        {
            List<User> AllUsers = _userFactory.FindAll().ToList();
            ViewBag.Users = AllUsers;
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



    }
}
