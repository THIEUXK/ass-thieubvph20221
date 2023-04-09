using ass_thieubvph20221.Models;

namespace ass_thieubvph20221.Services.iservices
{
    public interface INhanVienService
    {
        // Các phương thức lấy ra sản phẩm
        public List<nhanVien> GetAllnhanViens();
        public nhanVien GetNhanVienById(Guid id);
        public List<nhanVien> GetNhanVienByName(string name);
        // Phương thức Thêm
        public bool Create(nhanVien p);
        // Phương thức Sửa
        public bool Update(nhanVien p);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
