using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;
using System.Collections.Generic;


    namespace ViewModelFun.Controllers     //be sure to use your own project's namespace!
    {
        public class MiniController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public ViewResult Message()
            {
                Message message = new Message()
                {
                    MainMessage = "Hi I am a message"
                };
                return View(message);
            }

            [HttpGet]
            [Route("numbers")]
            public ViewResult Numbers()
            {
                Numbers list = new Numbers(){
                    NumberList = new int[] {1,2,3,4,5}
                };
                return View(list);
            }
            [HttpGet]
            [Route("users")]
            public ViewResult Users()
            {
                User Bob = new User(){
                    FirstName = "Bob",
                    Lastname = "Bobby"
                };
                User Tom = new User(){
                    FirstName = "Tom",
                    Lastname = "Tommy"
                };
                User Rob = new User(){
                    FirstName = "Rob",
                    Lastname = "Robby"
                };
                List<User> list = new List<User>{};
                list.Add(Bob);
                list.Add(Rob);
                list.Add(Tom);
                return View(list);
            }
            [HttpGet]
            [Route("user")]
            public ViewResult User()
            {
                User Bob = new User(){
                    FirstName = "Bob",
                    Lastname = "Bobby"
                };
                
                return View(Bob);
            }
        }
    }