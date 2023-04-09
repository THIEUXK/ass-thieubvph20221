using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class shopController : Controller
    {
        private readonly ILogger<shopController> _logger;
        private readonly giayService _giayService;


        public shopController(ILogger<shopController> logger)
        {
            _giayService = new giayService();
            _logger = logger;
        }
        public IActionResult shop()
        {
            List<giay> giays = _giayService.GetAllgiay();
            return View(giays);
        }
        public IActionResult chiTietSP()
        {

           
            return View();
        }
        public IActionResult chiTietSP(Guid id)
        {

            giay giay = _giayService.GetgiayById(id);
            return View(giay);
        }
       
        public IActionResult Redirect()
        {
            // List fake
            //var products = new List<Product>() {
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt gà", Price = 1000, AvailableQuantity = 15,
            //    Status = 1,Supplier = "KhanhPG", Description = "Ngon" },
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt bò", Price = 2000, AvailableQuantity = 14,
            //    Status = 1,Supplier = "DungNA29", Description = "Rất Ngon" },
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt lợn", Price = 900, AvailableQuantity = 12,
            //    Status = 1,Supplier = "TienNH21", Description = "Hơi Ngon" }
            //};
            List<giay> products = _giayService.GetAllgiay();
            return View("giay", products); // Trả về 1 View Cụ thể đi kèm với Model
        }
        public IActionResult GioHang(Guid id)
        {

            return View();
        }
    }
}
