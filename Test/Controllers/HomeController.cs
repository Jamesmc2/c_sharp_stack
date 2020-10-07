using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private TestContext dbContext;
        public HomeController(TestContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("user/create")]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Register");
                }
                if (dbContext.Users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Username already in use!");
                    return View("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("HomePage");
            }
            else
            {
                return View("Register");
            }
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet("/HomePage")]
        public IActionResult HomePage()
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId");
            ViewBag.LoggedUser = dbContext.Users.FirstOrDefault(user => user.UserId == LoggedId);
            ViewBag.Hobbies = dbContext.Hobbies;
            List<int> counts = new List<int>();
            foreach (var hobby in dbContext.Hobbies)
            {
                int NumOfUsers = dbContext.Hobbies
        .Include(hob => hob.Intrested)
        .FirstOrDefault(hob => hob.HobbyId == hobby.HobbyId)
        .Intrested.Count;
                counts.Add(NumOfUsers);
            }
            ViewBag.counts = counts;


            return View();
        }
        [HttpGet("NewHobby")]
        public IActionResult NewHobby()
        {
            return View();
        }
        [HttpPost("CreateHobby")]
        public IActionResult CreateHobby(Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(hobby);
                dbContext.SaveChanges();
                return RedirectToAction("HomePage");
            }
            else
            {
                return View("AddHobby");
            }
        }
        [HttpGet("Hobby/{HobbyId}")]
        public IActionResult ShowHobby(int HobbyId)
        {
            var HobbyWithUsers = dbContext.Hobbies
        .Include(Hobby => Hobby.Intrested)
        .ThenInclude(Intrest => Intrest.User)
        .FirstOrDefault(Hobby => Hobby.HobbyId == HobbyId);

            return View(HobbyWithUsers);
        }
        public IActionResult CheckLogin(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if (result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }
            }
            User LoggedUser = dbContext.Users.FirstOrDefault(user => user.Email == userSubmission.Email);
            HttpContext.Session.SetInt32("UserId", LoggedUser.UserId);
            return RedirectToAction("Homepage");
        }
        [HttpGet("AddHobby/{id}")]
        public IActionResult AddHobby(int id)
        {

            int? LoggedId = HttpContext.Session.GetInt32("UserId");
            Intrest NewIntrest = new Intrest()
            {
                UserId = (int)LoggedId,
                HobbyId = id,
            };
            dbContext.Add(NewIntrest);
            dbContext.SaveChanges();

            return Redirect($"/Hobby/{id}");
        }
    }
}