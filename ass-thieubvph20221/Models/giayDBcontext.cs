using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ass_thieubvph20221.Models
{
    public class giayDBcontext:DbContext
    {
        public giayDBcontext(){}

        public giayDBcontext( DbContextOptions options):base(options)
        {
        }
        public DbSet<khachHang> KhachHangs { get; set; }
        public DbSet<giay>Giays{ get; set; }
        public DbSet<hoaDon>HoaDons { get; set; }
        public DbSet<chiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=ass;User ID=thieubvph20221;Password=thieu12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
