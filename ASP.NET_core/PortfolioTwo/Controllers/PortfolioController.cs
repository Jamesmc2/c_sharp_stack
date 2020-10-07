    using Microsoft.AspNetCore.Mvc;
    namespace portfolio.Controllers     //be sure to use your own project's namespace!
    {
        public class MiniViewsController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult Index()
            {
                return View();
            }
            [HttpGet]       //type of request
            [Route("Projects")]     //associated route string (exclude the leading /)
            public ViewResult Projects()
            {
                return View();
            }
            [HttpGet]       //type of request
            [Route("Contact")]     //associated route string (exclude the leading /)
            public ViewResult Contact()
            {
                return View();
            }
        }
    }
