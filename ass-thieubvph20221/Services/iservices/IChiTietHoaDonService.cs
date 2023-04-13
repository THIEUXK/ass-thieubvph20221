using ass_thieubvph20221.Models;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IChiTietchiTietHoaDonService
    {
        // Các phương thức lấy ra sản phẩm

        public List<chiTietHoaDon> GetAllchiTietHoaDons();
        public List<chiTietHoaDon> GetchiTietHoaDonnById(Guid id);
        public List<chiTietHoaDon> GetchiTietHoaDonByName(string name);
        // Phương thức Thêm
        public bool Create(chiTietHoaDon p);
        // Phương thức Sửa
        public bool Update(chiTietHoaDon p);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
