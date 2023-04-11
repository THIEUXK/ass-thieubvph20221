using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services
{
    public class GioHangService:IGioHangservice
    {
        public List<GioHang> iggioHangs;
        //bien
        public List<nhanVien> igNhanVien;
        //bien
        public List<khachHang> igKhachhang;
        giayDBcontext context;

        public GioHangService()
        {
            iggioHangs=new List<GioHang>();
            igNhanVien=new List<nhanVien>();
            igKhachhang = new List<khachHang>();
            context = new giayDBcontext();
        }


        public List<GioHangView> GetAllGioHangvViewss()
        {
            List<GioHangView> lst = (from a in iggioHangs
                join b in igNhanVien on a.idNhanVien equals b.id
                join c in igKhachhang on a.idKhachHang equals c.id into gj
                from x in gj.DefaultIfEmpty()
                select new GioHangView()
                {
                    GioHang = a,
                    NhanVien = b,
                    KhachHang = x ?? null
                }).ToList();
            return lst;
        }

        public List<GioHang> GetAllGioHangs()
        {
            return context.GioHangs.ToList();
        }

        public GioHang GetGioHangById(Guid id)
        {
            return context.GioHangs.FirstOrDefault(p => p.id == id);
        }

        public List<GioHang> GetGioHangByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(GioHang p)
        {
            try
            {
                p.id = Guid.NewGuid();
                context.GioHangs.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(GioHang p)
        {
            try
            {
                var a = context.GioHangs.Find(p.id);
                a.KhachHang = p.KhachHang;
                a.NhanVien = p.NhanVien;
                a.mota=p.mota;
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
                var nv = context.GioHangs.Find(id);
                context.GioHangs.Remove(nv);
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
