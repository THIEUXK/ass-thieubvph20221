using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;

namespace ass_thieubvph20221.Services
{
    public class giayService:IGiayService
    {
        giayDBcontext context;
        public giayService()
        {
            context = new giayDBcontext();
        }
        public bool Creategiay(giay p)
        {
            try
            {
                context.Giays.Add(p);
               
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Deletegiay(Guid id)
        {
            try
            {
                var giay = context.Giays.Find(id);
                context.Giays.Remove(giay);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<giay> GetAllgiay()
        {
            return context.Giays.ToList();// Lấy tất cả các sản phẩm
        }

        public giay GetgiayById(Guid id)
        {
            return context.Giays.FirstOrDefault(p => p.id == id);
            // return context.giays.SingleOrDefault(p => p.ID == id);
        }

        public List<giay> GetgiayByName(string name)
        {
            return context.Giays.Where(p => p.tenGiay.Contains(name)).ToList();
            // Trả về danh sách những Sản phẩm mà tên có chứa chuỗi cần tìm
        }

        public bool Updategiay(giay p)
        {
            try
            {
                var giay = context.Giays.Find(p.id);
                giay.tenGiay=p.tenGiay;
                giay.chatLieu=p.chatLieu;
                giay.donGiaNhap=p.donGiaNhap;
                giay.donGiaban=p.donGiaban;
                giay.ghiChu=p.ghiChu;
                giay.anh =p.anh;
                giay.soLuong=p.soLuong;
                
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
