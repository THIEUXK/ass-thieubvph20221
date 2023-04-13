using ass_thieubvph20221.Models;

namespace ass_thieubvph20221.ViewModel
{
    public class GioHangView
    {
        public List<GioHang> GioHangs { get; set; } = new();

        public List<ChiTietGioHang> ChiTietGioHangs { get; set; } = new();
        public int tongtien { get; set; } = new();
    }
}
