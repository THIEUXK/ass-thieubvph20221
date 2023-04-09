using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using ass_thieubvph20221.Services.iservices;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class loginController : Controller
    {
        private readonly ILogger<loginController> _logger;


        public loginController(ILogger<loginController> logger)
        {
            _logger = logger;
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult dangKi()
        {
            return View();
        }
    }
}
      



      
      










