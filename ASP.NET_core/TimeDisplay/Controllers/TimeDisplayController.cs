using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class MiniController : Controller
    {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult DisplayTime()
            {
                return View();
            }
        }
}