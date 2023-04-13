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
            var e = _chiTietGioHangService.GetAllChiTietGioHangs();
            var tong = 0;
            foreach (var x in e)
            {
               tong+= x.Giay.donGiaban.Value*x.soLuong.Value;
               
            }
            var f = new ChiTietGioHangView() { ChiTietGioHangs = e, tongtien = tong};
          
            return View(f);

        }

        [HttpPost]
        public IActionResult addto(Guid id, int soluong)
        {
            var gioHang = _gioHangService.GetAllGioHangs();
            if (gioHang.Count == 0)
            {
                var a = new GioHang()
                {
                    idKhachHang = Guid.Parse("aedd5495-cd5c-4061-7246-08db3b445411"),
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
                var b = new ChiTietGioHang()
                {
                    idGiay = id,
                    idGioHang = Guid.Parse("DD52BE9C-E183-467C-B9F5-819BFB0A458F"),
                    soLuong = soluong,
                    trangThai = 0,
                };
                if (_chiTietGioHangService.Create(b))
                {
                    return RedirectToAction("GioHang");
                }
            }
            else
            {
                var SP = _chiTietGioHangService.GetAllChiTietGioHangs().FirstOrDefault(c => c.idGiay == id);
                if (SP == null)
                {
                    var chitietgiohang = new ChiTietGioHang()
                    {
                        idGiay = id,
                        idGioHang = Guid.Parse("dd52be9c-e183-467c-b9f5-819bfb0a458f"),
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
            var a = _chiTietGioHangService.GetAllChiTietGioHangs();
            int tong = 0;
            foreach (var x in a)
            {
                tong += x.Giay.donGiaban.Value * x.soLuong.Value;
            }
            var b = new ChiTietGioHangView() { ChiTietGioHangs = a, tongtien = tong};
            return View("ThanhToan", b);

        }
        [HttpPost]
        public IActionResult SauThanhToan(ChiTietGioHangView a)
        {
            var a1 = new List<giay>();
            //Kiểm tra số lượng sản phẩm trong giỏ hàng với số lượng sản phẩm còn lại
            foreach (var CT in a.ChiTietGioHangs)
            {
                var b = CT.Giay;
                var sp = _giayService.GetgiayById(CT.idGiay.Value);
                if (sp.soLuong < CT.soLuong)
                {
                    a1.Add(sp);
                }
            }
            if (a1.Count > 0)
            {
                // Trả về thông báo lỗi nếu có sản phẩm không đủ số lượng để thanh toán
                var message = "không đử số lượng để thanh toán ";
                foreach (var item in a1)
                {
                    message += item.tenGiay + ", ";
                }
                message = message.Substring(0, message.Length - 2);
                TempData["ErrorMessage"] = message;
                return RedirectToAction("ThanhToan", "shop", new { message });
            }
            else
            {
                Guid ida =Guid.NewGuid();
                //Tạo hóa đơn mới
                int tong=0;
                foreach (var inso in _chiTietGioHangService.GetAllChiTietGioHangs())
                {
                    tong += Int32.Parse(inso.soLuong.ToString())* Int32.Parse(inso.Giay.donGiaban.ToString());
                }
                
                var hd = new hoaDon()
                {
                    id = ida,
                    ngayBan = DateTime.Now,
                //UserId = currentUserId, //Id của người dùng đang Login
                idKhachHang = Guid.Parse("aedd5495-cd5c-4061-7246-08db3b445411"),
                    tongTien = tong,
                };
                if (_hoaDonService.Create(hd) == false)
                    return RedirectToAction("ThanhToan", "shop");

                //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (var ct in _chiTietGioHangService.GetAllChiTietGioHangs())
                {
                    var cthd = new chiTietHoaDon()
                    {
                        idHoaDon = ida, //Id của hóa đơn vừa tạo
                       idGiay = ct.idGiay,
                       donGia = Int32.Parse(ct.Giay.donGiaban.ToString()),
                       soLuong = int.Parse(ct.soLuong.ToString()),
                       thanhTien = (ct.Giay.donGiaban*ct.soLuong),
                       giamGia = 0,
                    };
                    if (_chiTietHoaDon.Create(cthd) == false)
                        return RedirectToAction("ThanhToan", "shop");
                    //Trừ số lượng sản phẩm trong CSDL
                    var product = _giayService.GetgiayById(cthd.idGiay.Value);
                    product.soLuong -= ct.soLuong;
                    _giayService.Updategiay(product);
                    if (_chiTietGioHangService.Delete(ct.id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                        return RedirectToAction("ThanhToan", "shop");
                }
                return RedirectToAction("GioHang");
            }

        }

        public IActionResult lisHoaDon()
        {
            var a = _hoaDonService.GetAllhoaDons().Where(c=>c.tongTien>0).ToList();
            var b = new HoaDonView() {HoaDons = a};
            return View(b);
        }
        public IActionResult xoalisHoaDon(Guid id)
        {
            if (_hoaDonService.Delete(id))
            {
                return RedirectToAction("lisHoaDon");
            }

            return RedirectToAction("lisHoaDon");
        }
        public IActionResult CTlisHoaDon(Guid id)
        {
            var a = _chiTietHoaDon.GetchiTietHoaDonnById(id);
            var b = new HoaDonChiTietView() { ChiTietHoaDons = a };
            return View(b);
        }


    }
}
