using Microsoft.AspNetCore.Mvc;
    namespace DojoSurvey.Controllers     //be sure to use your own project's namespace!
    {
        public class MiniController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult Survey()
            {
                return View();
            }

            [HttpPost]
            [Route("Result")]
            public IActionResult Result(string Name, string Location, string Language, string Comment)
            {
                ViewBag.Name = Name;
                ViewBag.Location = Location;
                ViewBag.Language = Language;
                ViewBag.Comment = Comment;
                return View();
            }

        }
    }