using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace ass_thieubvph20221.Controllers
{
    public class giayController : Controller
    {
        private readonly ILogger<giayController> _logger;
        private readonly giayService _giayService;

        public giayController(ILogger<giayController> logger)
        {
            _giayService = new giayService();
            _logger = logger;
        }
        public IActionResult giay()
        {
            List<giay> giays = _giayService.GetAllgiay();
            return View(giays);
        }
        public IActionResult loc()
        {
            List<giay> giays = _giayService.GetAllgiay().Where(c => c.soLuong > 0).ToList();
            return View(giays);
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


        public IActionResult addGiay()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addGiay(giay p,[Bind]IFormFile imageFile)
        {
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                p.anh = imageFile.FileName;
            }

            if (_giayService.Creategiay(p)) // Nếu thêm thành công
                {

                return RedirectToAction("Redirect");
            }

            return View();
        }



        public IActionResult updateGiay(giay p, Guid id, [Bind] IFormFile imageFile)
        {
            // Code
            // Từ Id lấy được của Sản phẩm ta lấy ra sản phẩm đó
            var product = _giayService.GetgiayById(id);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "UpDate");



            if (products.Count == 0)
            {
                products.Add(product); // Nếu Cart rỗng thì thêm sp vào luôn
                // Đưa dữ liệu về lại Session
                SessionServices.SetObjToJson(HttpContext.Session, "UpDate", products);
            }
            else
            {
                if (!SessionServices.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product); // Nếu Cart rỗng thì thêm sp vào luôn
                    // Đưa dữ liệu về lại Session
                    SessionServices.SetObjToJson(HttpContext.Session, "UpDate", products);
                }
                else
                {
                    var check = products.FirstOrDefault(p => p.id == p.id);
                    products.Remove(check);
                    products.Add(product); // Nếu Cart rỗng thì thêm sp vào luôn
                    // Đưa dữ liệu về lại Session
                    SessionServices.SetObjToJson(HttpContext.Session, "UpDate", products);


                }


            }
            
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                p.anh = imageFile.FileName;
            }

            if (_giayService.Updategiay(p))
            {
                return RedirectToAction("giay");

            }
            return View();
        }
        public IActionResult RollBack(giay p, Guid id)
        {
            // Code
            // Từ Id lấy được của Sản phẩm ta lấy ra sản phẩm đó
            var s = SessionServices.GetObjFromSession(HttpContext.Session, "UpDate").FirstOrDefault(c => c.id == id);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?

            if (_giayService.Updategiay(s))
            {
                return RedirectToAction("ShowUpDate");

            }
            return RedirectToAction("Redirect");
        }


        public IActionResult cuUpdate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult updateGiay(Guid id)
        {
            giay giay = _giayService.GetgiayById(id);
            return View(giay);
        }


        public IActionResult Delete(Guid id)
        {
            if (_giayService.Deletegiay(id))
            {
                return RedirectToAction("Redirect");
            }
            else return View("giay");
        }


        public IActionResult Details(Guid id)
        {
            giay giay = _giayService.GetgiayById(id);
            return View(giay);
        }

        public IActionResult AddToCart(Guid id)
        {
            // Code
            // Từ Id lấy được của Sản phẩm ta lấy ra sản phẩm đó
            var product = _giayService.GetgiayById(id);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (products.Count == 0)
            {
                products.Add(product); // Nếu Cart rỗng thì thêm sp vào luôn
                // Đưa dữ liệu về lại Session
                SessionServices.SetObjToJson(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (!SessionServices.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product); // Nếu Cart chưa chứa sản phẩm thì thêm sp vào luôn
                    // Đưa dữ liệu về lại Session
                    SessionServices.SetObjToJson(HttpContext.Session, "Cart", products);
                }
                else return Content("Sản phẩm đã nằm trong giỏ");
            }
            // Lấy từ Session
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            // Đọc dữ liệu từ Session và truyền vào View
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            return View(products);
        }
        public IActionResult ShowUpDate()
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "UpDate");
            return View(products);
        }

    }
}
