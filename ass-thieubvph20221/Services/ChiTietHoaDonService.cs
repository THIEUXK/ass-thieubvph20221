using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services
{
    public class ChiTietHoaDonService:IChiTietchiTietHoaDonService
    {
        public List<hoaDon> igHoaDon;
        //bien
        public List<giay> IggiGiays;
        //bien
        public List<chiTietHoaDon> IgcChiTietHoaDons;
        giayDBcontext context;

        public ChiTietHoaDonService()
        {
            igHoaDon = new List<hoaDon>();
            IggiGiays = new List<giay>();
            IgcChiTietHoaDons = new List<chiTietHoaDon>();
            context = new giayDBcontext();
        }
        public List<HoaDonChiTietView> GetAllchiTietHoaDonvViewss()
        {
            List<HoaDonChiTietView> lst = (from a in IgcChiTietHoaDons
                join b in IggiGiays on a.idGiay equals b.id
                join c in igHoaDon on a.idHoaDon equals c.id into gj
                from x in gj.DefaultIfEmpty()
                select new HoaDonChiTietView()
                {
                    ChiTietHoaDon = a,
                    Giay = b,
                    HoaDon = x ?? null
                }).ToList();
            return lst;
        }

        public List<chiTietHoaDon> GetAllchiTietHoaDons()
        {
            return context.ChiTietHoaDons.ToList();
        }

        public chiTietHoaDon GetchiTietHoaDonnById(Guid id)
        {
            return context.ChiTietHoaDons.FirstOrDefault(p => p.id == id);
        }

        public List<chiTietHoaDon> GetchiTietHoaDonByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(chiTietHoaDon p)
        {
            try
            {
                context.ChiTietHoaDons.Add(p);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(chiTietHoaDon p)
        {
            try
            {
                var a = context.ChiTietHoaDons.Find(p.id);
                a.Giay=p.Giay;
                a.HoaDon=p.HoaDon;
                a.donGia=p.donGia;
                a.giamGia=p.giamGia;
                a.soLuong=p.soLuong;
                a.thanhTien=p.thanhTien;
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(chiTietHoaDon id)
        {
            try
            {
                var nv = context.ChiTietHoaDons.Find(id);
                context.ChiTietHoaDons.Remove(nv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
