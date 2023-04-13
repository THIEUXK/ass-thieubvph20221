using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ass_thieubvph20221.Services
{
    public class HoaDonService:IHoaDonService
    {
        public List<hoaDon> igHoaDon;
        //bien
    
        //bien
        public List<khachHang> igKhachhang;
        giayDBcontext context;

        public HoaDonService()
        {
            igHoaDon = new List<hoaDon>();

            igKhachhang = new List<khachHang>();
            context = new giayDBcontext();
        }


        public List<hoaDon> GetAllhoaDons()
        {
            return context.HoaDons.Include(c=>c.KhachHang).ToList();
        }


        public hoaDon GethoaDonnById(Guid id)
        {
            return context.HoaDons.FirstOrDefault(p => p.id == id);
        }

        public List<hoaDon> GethoaDonByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(hoaDon p)
        {
            try
            {
                
                context.HoaDons.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(hoaDon p)
        {
            try
            {
                var a = context.HoaDons.Find(p.id);
                a.KhachHang=p.KhachHang;
                a.tongTien=p.tongTien;
                a.ngayBan=p.ngayBan;
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
                var nv = context.HoaDons.Find(id);
                context.HoaDons.Remove(nv);
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
