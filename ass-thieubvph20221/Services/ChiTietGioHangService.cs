using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ass_thieubvph20221.Services
{
    public class ChiTietGioHangService : IChiTietGioHangService
    {
      

        //bien
        public List<ChiTietGioHang> IgcChiTietGioHangs;
        giayDBcontext context;

        public ChiTietGioHangService()
        {
            IgcChiTietGioHangs = new List<ChiTietGioHang>();
           
            context = new giayDBcontext();
           
            
        }


        public List<ChiTietGioHangView> GetAllTietGioHangViews()
        {
            throw new NotImplementedException();
        }

        public List<ChiTietGioHang> GetAllChiTietGioHangs()
        {
            return context.ChiTietGioHangs.Include(c => c.Giay).Include(c => c.GioHang).ToList();//lay tat ca
        }

        public ChiTietGioHang GetChiTietGioHangnById(Guid id)
        {
            return context.ChiTietGioHangs.FirstOrDefault(p => p.id == id);
        }

        public List<ChiTietGioHang> GetChiTietGioHangByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(ChiTietGioHang p)
        {
            try
            {
                p.id = new Guid();
                context.ChiTietGioHangs.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ChiTietGioHang p)
        {
            try
            {
                var a = context.ChiTietGioHangs.Find(p.id);
                a.Giay = p.Giay;
                a.trangThai = p.trangThai;
                a.GioHang = p.GioHang;
                a.soLuong = p.soLuong;
                context.SaveChanges();
                return true;
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
                var nv = context.ChiTietGioHangs.Find(id);
                context.ChiTietGioHangs.Remove(nv);
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