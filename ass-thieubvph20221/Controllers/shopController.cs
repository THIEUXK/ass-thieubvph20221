using System.Runtime.InteropServices.ComTypes;
using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using ass_thieubvph20221.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class shopController : Controller
    {
        private readonly ILogger<shopController> _logger;
        private readonly giayService _giayService;
        private readonly HoaDonService _hoaDonService;
        private readonly GioHangService _gioHangService;
        private readonly ChiTietHoaDonService _chiTietHoaDon;
        private readonly ChiTietGioHangService _chiTietGioHangService;
        giayDBcontext context;



        public shopController(ILogger<shopController> logger)
        {
            _giayService = new giayService();
            _hoaDonService = new HoaDonService();
            _logger = logger;
            _chiTietHoaDon = new ChiTietHoaDonService();
            _gioHangService = new GioHangService();
            _chiTietGioHangService = new ChiTietGioHangService();
            context = new giayDBcontext();
        }
        public IActionResult shop()
        {
            List<giay> giays = _giayService.GetAllgiay();
            return View(giays);
        }
      
        public IActionResult chiTietSP(Guid id)
        {
            giay giay = _giayService.GetgiayById(id);
            return View(giay);

        }
        public IActionResult GioHang()
        {
            var e = _chiTietGioHangService.GetAllTietGioHangViews();
            var tong = 0;
            foreach (var x in e)
            {
               tong+= x.Giay.donGiaban.Value*x.CTietGioHang.soLuong.Value;
               x.tongtien = tong;

            }

            return View(e);
        }
        [HttpPost]
        public IActionResult AddToHoaDon(Guid id,int soluong)
        {
            

            
            var gioHang = _gioHangService.GetAllGioHangs();
            if (gioHang.Count==0)
            {
                var a = new GioHang()
                {
                    idKhachHang = Guid.Parse("A4B0F757-08CC-48D9-7285-08DB38F2B5AB"),
                    idNhanVien = Guid.Parse("96174FAC-B1AC-4925-4579-08DB38F2B0AB"),
                    mota = "",
                };
                if (_gioHangService.Create(a))
                {
                    return RedirectToAction("GioHang");
                }
            }
            
            var CTGiohangn = _chiTietGioHangService.GetAllChiTietGioHangs().FirstOrDefault(c => c.idGiay == id);
            if (CTGiohangn == null)
            {
                var chitietgiohang = new ChiTietGioHang()
                {
                    idGiay = id ,
                    idGioHang = Guid.Parse("3E77EF9D-7978-4E2A-91F1-757CCCDB0523"),
                    soLuong = soluong ,
                    trangThai = 0,
                };
                if (_chiTietGioHangService.Create(chitietgiohang))
                {
                    return RedirectToAction("GioHang");
                }
            }
            else
            {
                var SP = _chiTietGioHangService.GetAllChiTietGioHangs().FirstOrDefault(c => c.idGiay == id);
                if (SP==null)
                {
                    var chitietgiohang = new ChiTietGioHang()
                    {
                        idGiay = id,
                        idGioHang = Guid.Parse("3E77EF9D-7978-4E2A-91F1-757CCCDB0523"),
                        soLuong = soluong,
                        trangThai = 0,
                    };
                    if (_chiTietGioHangService.Create(chitietgiohang))
                    {
                        return RedirectToAction("GioHang");
                    }
                }
                else
                {
                 
                    SP.soLuong += soluong;
                    if (_chiTietGioHangService.Update(SP))
                    {
                        return RedirectToAction("GioHang");
                    }
                }
               
            }
            return RedirectToAction("GioHang");
        }
       
        public IActionResult Redirect()
        {
            List<giay> products = _giayService.GetAllgiay();
            return View("giay", products); // Trả về 1 View Cụ thể đi kèm với Model
        }
        public IActionResult XoaGH(Guid id)
        {
            if (_chiTietGioHangService.Delete(id))
            {
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public IActionResult ThanhToan(Guid id)
        {
            
            return RedirectToAction("GioHang");
        }



    }
}
