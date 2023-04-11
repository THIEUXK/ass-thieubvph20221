using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class gioHangConfiguration: IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.mota);
            
            builder.HasOne(c => c.KhachHang).WithMany(c => c.GioHangs).HasForeignKey(c => c.idKhachHang);
            builder.HasOne(c => c.NhanVien).WithMany(c => c.GioHangs).HasForeignKey(c => c.idNhanVien);
        }
    }
}
