using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;

namespace ass_thieubvph20221.Services
{
    public class KhachHangService:IKhachHangService
    {
        giayDBcontext context;

        public KhachHangService()
        {
            context = new giayDBcontext();
        }
        public List<khachHang> GetAllkhachHangs()
        {
            return context.KhachHangs.ToList();
        }

        public khachHang GetkhachHangnById(Guid id)
        {
            return context.KhachHangs.FirstOrDefault(p => p.id == id);
        }

        public List<khachHang> GetkhachHangByName(string name)
        {
            return context.KhachHangs.Where(p => p.tenKH.Contains(name)).ToList();
            // Trả về danh sách những Sản phẩm mà tên có chứa chuỗi cần tìm
        }

        public bool Create(khachHang p)
        {
            try
            {
                context.KhachHangs.Add(p);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(khachHang p)
        {
            try
            {
                var a = context.KhachHangs.Find(p.id);
               a.tenKH=p.tenKH;
               a.diaChi=p.diaChi;
               a.sDT=p.sDT;
               
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var nv = context.KhachHangs.Find(id);
                context.KhachHangs.Remove(nv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
