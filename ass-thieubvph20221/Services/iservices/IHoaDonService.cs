using ass_thieubvph20221.Models;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IHoaDonService
    {
        // Các phương thức lấy ra sản phẩm
        public List<HoaDonView> GetAllhoaDonViews();
        public List<hoaDon> GetAllhoaDons();
        public hoaDon GethoaDonnById(Guid id);
        public List<hoaDon> GethoaDonByName(string name);
        // Phương thức Thêm
        public bool Create(hoaDon p);
        // Phương thức Sửa
        public bool Update(hoaDon p);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
