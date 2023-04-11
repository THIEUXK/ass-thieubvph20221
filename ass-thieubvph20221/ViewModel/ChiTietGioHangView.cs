using ass_thieubvph20221.Models;

namespace ass_thieubvph20221.ViewModel
{
    public class ChiTietGioHangView
    {
        public ChiTietGioHang CTietGioHang { get; set; } = new();
        public GioHang GioHang { get; set; } = new();
        public giay Giay { get; set; } = new();

        public int tongtien { get; set; } = new();
    }
}
