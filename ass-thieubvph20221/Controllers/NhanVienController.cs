using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using ass_thieubvph20221.Services.iservices;
using Microsoft.AspNetCore.Mvc;

namespace ass_thieubvph20221.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ILogger<loginController> _logger;
        private readonly NhanVienService _nhanVienService;

     

        public NhanVienController()
        {
            _nhanVienService = new NhanVienService();
        }
        public IActionResult QLNhanVien()
        {
            List<nhanVien> nhanvien = _nhanVienService.GetAllnhanViens();
            return View(nhanvien);
        }
        public IActionResult RedirectNV()
        {

            List<nhanVien> products = _nhanVienService.GetAllnhanViens();
            return View("QLNhanVien", products); // Trả về 1 View Cụ thể đi kèm với Model
        }
        public IActionResult AddQLNhanVien()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddQLNhanVien(nhanVien p)
        {
            if (_nhanVienService.Create(p)) // Nếu thêm thành công
            {

                return RedirectToAction("RedirectNV");
            }
            return View();

        }
       

       
        public IActionResult UpdateNV(nhanVien p)
        {
            if (_nhanVienService.Update(p))
            {
                return RedirectToAction("RedirectNV");

            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateNV(Guid id)
        {
            nhanVien nhanVien = _nhanVienService.GetNhanVienById(id);
            return View(nhanVien);
        }
        public IActionResult DeleteNV(Guid id)
        {
            if (_nhanVienService.Delete(id))
            {
                return RedirectToAction("RedirectNV");
            }
            else return View("QLNhanVien");
        }
        public IActionResult DetailsNV(Guid id)
        {
            nhanVien nhanvien = _nhanVienService.GetNhanVienById(id);
            return View(nhanvien);
        }
    }
}
