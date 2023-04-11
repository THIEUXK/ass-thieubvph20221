namespace ass_thieubvph20221.Models
{
    public class nhanVien
    {
        public Guid id { get; set; }
        public string? tenNV { get; set; }
        public string? gioiTinh { get; set; }
        public string? diaChi { get; set; }
        public string? sDT { get; set; }
        public DateTime? ngaySinh { get; set; }
        public List<hoaDon>HoaDon { get; set; }

        public List<GioHang> GioHangs { get; set; }
    }
}
