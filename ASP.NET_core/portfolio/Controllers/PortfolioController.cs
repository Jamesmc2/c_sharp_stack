    using Microsoft.AspNetCore.Mvc;
    namespace portfolio.Controllers     //be sure to use your own project's namespace!
    {
        public class PortfolioController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public string Index()
            {
                return "This is my Index!";
            }
            [HttpGet]       //type of request
            [Route("projects")]     //associated route string (exclude the leading /)
            public string projects()
            {
                return "These are my projects!";
            }
            [HttpGet]       //type of request
            [Route("contact")]     //associated route string (exclude the leading /)
            public string contact()
            {
                return "This is my contact!";
            }
        }
    }
