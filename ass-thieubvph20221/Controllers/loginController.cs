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
        public IActionResult QLCuaHang()
        {
            return View();
        }
    }
}
