using ass_thieubvph20221.Models;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IChiTietGioHangService
    {
        
        public List<ChiTietGioHangView> GetAllTietGioHangViews();
        public List<ChiTietGioHang> GetAllChiTietGioHangs();
        public ChiTietGioHang GetChiTietGioHangnById(Guid id);
        public List<ChiTietGioHang> GetChiTietGioHangByName(string name);
        // Phương thức Thêm
        public bool Create(ChiTietGioHang p);
        // Phương thức Sửa
        public bool Update(ChiTietGioHang p);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
