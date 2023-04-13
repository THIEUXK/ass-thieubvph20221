using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;
using Microsoft.EntityFrameworkCore;

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
        

        public List<chiTietHoaDon> GetAllchiTietHoaDons()
        {
            return context.ChiTietHoaDons.Include(c=>c.HoaDon).Include(c=>c.Giay).ToList();
        }

        public List<chiTietHoaDon> GetchiTietHoaDonnById(Guid id)
        {
            return context.ChiTietHoaDons.Include(c => c.HoaDon).Include(c => c.Giay).Where(c=>c.idHoaDon==id).ToList();
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

        public bool Delete(Guid id)
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
