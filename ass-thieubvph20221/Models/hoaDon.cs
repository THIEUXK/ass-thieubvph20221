namespace ass_thieubvph20221.Models
{
    public class hoaDon
    { 
        public Guid id { get; set; }
        public Guid idNhanVien { get; set; }
        public  Guid idKhachHang { get; set; }
        public DateTime ngayBan { get; set; }
        public int tongTien { get; set; }
        public  nhanVien NhanVien { get; set; }
        public khachHang KhachHang { get; set; }
        public List<chiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
