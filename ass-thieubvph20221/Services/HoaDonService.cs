using ass_thieubvph20221.Models;
using ass_thieubvph20221.Services.iservices;
using ass_thieubvph20221.ViewModel;

namespace ass_thieubvph20221.Services
{
    public class HoaDonService:IHoaDonService
    {
        public List<hoaDon> igHoaDon;
        //bien
        public List<nhanVien> igNhanVien;
        //bien
        public List<khachHang> igKhachhang;
        giayDBcontext context;

        public HoaDonService()
        {
            igHoaDon = new List<hoaDon>();
            igNhanVien = new List<nhanVien>();
            igKhachhang = new List<khachHang>();
            context = new giayDBcontext();
        }

        public List<HoaDonView> GetAllhoaDonViews()
        {
            List<HoaDonView> lst = (from a in igHoaDon
                join b in igNhanVien on a.idNhanVien equals b.id
                join c in igKhachhang on a.idKhachHang equals c.id into gj
                from x in gj.DefaultIfEmpty()
                select new HoaDonView()
                {
                    HoaDon = a,
                    NhanVien = b,
                    KhachHang = x ?? null
                }).ToList();
            return lst;
        }

        public List<hoaDon> GetAllhoaDons()
        {
            return context.HoaDons.ToList();
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
                a.NhanVien=p.NhanVien;
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
