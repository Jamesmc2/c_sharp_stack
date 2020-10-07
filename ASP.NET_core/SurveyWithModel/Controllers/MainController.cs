using SurveyWithModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace SurveyWithModel.Controllers
{
    public class MiniController : Controller{
        [HttpGet]
        [Route("")]
            public ViewResult Survey()
            {
                return View();
            }

        [HttpPost("Submission")]
        public IActionResult Submission(UserInfo yourSurvey)
        {
        
        return View(yourSurvey);
        }
    }
    
}