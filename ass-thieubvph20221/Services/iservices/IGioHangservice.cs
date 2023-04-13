using ass_thieubvph20221.Models;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IGioHangservice
    {

        public List<GioHang> GetAllGioHangs();
        public GioHang GetGioHangById(Guid id);
        public List<GioHang> GetGioHangByName(string name);
        // Phương thức Thêm
        public bool Create(GioHang p);
        // Phương thức Sửa
        public bool Update(GioHang p);
        // Phương thức xóa
        public bool Delete(Guid id);
    }
}
