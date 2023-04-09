using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class shopController : Controller
    {
        private readonly ILogger<shopController> _logger;
        private readonly giayService _giayService;
        private readonly HoaDonService _hoaDonService;


        public shopController(ILogger<shopController> logger)
        {
            _giayService = new giayService();
            _hoaDonService = new HoaDonService();
            _logger = logger;
        }
        public IActionResult shop()
        {

            if (_hoaDonService.GetAllhoaDons().Count == 0)
            {
                //_hoaDonService.Create(new hoaDon() { id = new Guid(), idKhachHang = null, idNhanVien = null, ngayBan = DateTime.Today });
            }
            List<giay> giays = _giayService.GetAllgiay();
            return View(giays);
        }
        public IActionResult chiTietSP()
        {

           
            return View();
        }
        public IActionResult chiTietSP(Guid id)
        {
            //new HoaDon()
            //    { MaHoaDon = maHoaDon, IdKhachHang = null, IdNhanVien = idNhanVien, PhuongThucMua = phuongThucMua };

            giay giay = _giayService.GetgiayById(id);
            return View(giay);
        }
       
        public IActionResult Redirect()
        {
            List<giay> products = _giayService.GetAllgiay();
            return View("giay", products); // Trả về 1 View Cụ thể đi kèm với Model
        }
     
       
        public IActionResult GioHang(Guid id, int soluong)
        {
            return View();
        }
        
    }
}
