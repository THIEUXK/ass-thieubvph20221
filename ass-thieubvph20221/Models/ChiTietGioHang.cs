namespace ass_thieubvph20221.Models
{
    public class ChiTietGioHang
    {
        public Guid id { get; set; }
        public Guid? idGioHang { get; set; }
        public Guid? idGiay { get; set; }
        public int? soLuong { get; set; }
        public int? trangThai { get; set; }
        public GioHang? GioHang { get; set; }
        public giay? Giay { get; set; }
    }
}
