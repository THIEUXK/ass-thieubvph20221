using ass_thieubvph20221.Models;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IKhachHangService
    {
        // Các phương thức lấy ra sản phẩm
        public List<khachHang> GetAllkhachHangs();
        public khachHang GetkhachHangnById(Guid id);
        public List<khachHang> GetkhachHangByName(string name);
        // Phương thức Thêm
        public bool Create(khachHang p);
        // Phương thức Sửa
        public bool Update(khachHang p);
        // Phương thức xóa
        public bool Delete(khachHang id);
    }
}
