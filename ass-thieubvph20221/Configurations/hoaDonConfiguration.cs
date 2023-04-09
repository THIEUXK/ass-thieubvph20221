using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class hoaDonConfiguration:IEntityTypeConfiguration<hoaDon>
    {
        public void Configure(EntityTypeBuilder<hoaDon> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.ngayBan);
            builder.Property(c => c.tongTien);
            builder.HasOne(c => c.KhachHang).WithMany(c => c.HoaDon).HasForeignKey(c => c.idKhachHang);
            builder.HasOne(c => c.NhanVien).WithMany(c => c.HoaDon).HasForeignKey(c => c.idNhanVien);
        }
    }
}
