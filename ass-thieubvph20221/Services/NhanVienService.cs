using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;

namespace ass_thieubvph20221.Services
{
    public class NhanVienService : INhanVienService
    {
        giayDBcontext context;

        public NhanVienService()
        {
            context = new giayDBcontext();
        }
        public List<nhanVien> GetAllnhanViens()
        {
            return context.NhanViens.ToList();
        }

        public nhanVien GetNhanVienById(Guid id)
        {
            return context.NhanViens.FirstOrDefault(p => p.id == id);
        }

        public List<nhanVien> GetNhanVienByName(string name)
        {
            return context.NhanViens.Where(p => p.tenNV.Contains(name)).ToList();
            // Trả về danh sách những Sản phẩm mà tên có chứa chuỗi cần tìm
        }

        public bool Create(nhanVien p)
        {
            try
            {
                context.NhanViens.Add(p);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(nhanVien p)
        {
            try
            {
                var nv = context.NhanViens.Find(p.id);
                nv.tenNV = p.tenNV;
                nv.diaChi=p.diaChi;
                nv.ngaySinh=p.ngaySinh;
                nv.gioiTinh=p.gioiTinh;
                nv.sDT=p.sDT;
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(nhanVien id)
        {
            try
            {
                var nv = context.NhanViens.Find(id);
                context.NhanViens.Remove(nv);
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
