using System.Data.SqlTypes;

namespace ass_thieubvph20221.Models
{
    public class khachHang
    {
        public Guid id { get; set; }
        public string? tenKH { get; set; }
        public string? diaChi { get; set; }
        public string? sDT { get; set; }
        public string? ChucVu { get; set; }
        public List<hoaDon>HoaDon { get; set; }
        public List<GioHang> GioHangs { get; set; }
    }
}
