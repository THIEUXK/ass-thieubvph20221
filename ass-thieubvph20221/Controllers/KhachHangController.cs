using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ILogger<loginController> _logger;
        private readonly KhachHangService _khachHangService;
        public KhachHangController()
        {
            _khachHangService = new KhachHangService();
        }
        public IActionResult QLKhanhHangs()
        {
            List<khachHang> khachhang = _khachHangService.GetAllkhachHangs();
            return View(khachhang);
        }
        public IActionResult RedirectKH()
        {

            List<khachHang> products = _khachHangService.GetAllkhachHangs();
            return View("QLKhanhHangs", products); // Trả về 1 View Cụ thể đi kèm với Model
        }
        public IActionResult AddQLKhanhHang()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddQLKhanhHang(khachHang p)
        {
            if (_khachHangService.Create(p)) // Nếu thêm thành công
            {

                return RedirectToAction("RedirectKH");
            }
            return View();

        }

        public IActionResult UpdateKH(khachHang p)
        {
            if (_khachHangService.Update(p))
            {
                return RedirectToAction("RedirectKH");
            }
            else return View();
        }
        [HttpGet]
        public IActionResult UpdateKH(Guid id)
        {
            khachHang khachHang = _khachHangService.GetkhachHangnById(id);
            return View(khachHang);
        }
      
        
        public IActionResult DeleteKH(Guid id)
        {
            if (_khachHangService.Delete(id))
            {
                return RedirectToAction("RedirectKH");
            }
            else return View("QLKhanhHangs");
        }
        public IActionResult DetailsKH(Guid id)
        {
            khachHang khachHang = _khachHangService.GetkhachHangnById(id);
            return View(khachHang);
        }

    }
}
