namespace ass_thieubvph20221.Models
{
    public class giay
    {
        public  Guid id { get; set; }
        public string tenGiay { get; set; }
        public string chatLieu { get; set; }
        public int soLuong { get; set; }
        public int donGiaNhap { get; set; }
        public int donGiaban { get; set; }
        public string anh { get; set; }
        public string ghiChu { get; set;}
        public List<chiTietHoaDon>ChiTietHoaDons { get; set; }

    }
}
