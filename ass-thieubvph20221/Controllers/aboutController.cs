using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class aboutController : Controller
    {
        private readonly ILogger<aboutController> _logger;


        public aboutController(ILogger<aboutController> logger)
        {
            _logger = logger;
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult vui()
        {
            return View();
        }
    }
}
