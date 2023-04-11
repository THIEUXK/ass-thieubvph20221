namespace ass_thieubvph20221.Models
{
    public class GioHang
    {
        public Guid id { get; set; }
        public Guid idNhanVien { get; set; }
        public Guid idKhachHang { get; set; }
        public string? mota { get; set; }
        public nhanVien? NhanVien { get; set; }
        public khachHang? KhachHang { get; set; }
        public List<ChiTietGioHang> CChiTietGioHangs { get; set; }
    }
}
