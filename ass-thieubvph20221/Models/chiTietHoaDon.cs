namespace ass_thieubvph20221.Models
{
    public class chiTietHoaDon
    {
        public  Guid id { get; set; }
        public Guid idHoaDon { get; set; }
        public Guid idGiay { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public int giamGia { get; set; }
        public int thanhTien { get; set; }
        public hoaDon HoaDon { get; set; }
        public giay Giay { get; set; }
    }
}
