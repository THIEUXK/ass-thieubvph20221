using ass_thieubvph20221.Models;

namespace ass_thieubvph20221.Services.iservices
{
    public interface IGiayService
    {
        // Các phương thức lấy ra sản phẩm
        public List<giay> GetAllgiay();
        public giay GetgiayById(Guid id);
        public List<giay> GetgiayByName(string name);
        // Phương thức Thêm
        public bool Creategiay(giay p);
        // Phương thức Sửa
        public bool Updategiay(giay p);
        // Phương thức xóa
        public bool Deletegiay(Guid id);
    }
}
