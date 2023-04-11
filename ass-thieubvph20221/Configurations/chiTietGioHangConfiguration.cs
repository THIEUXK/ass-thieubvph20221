using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class chiTietGioHangConfiguration: IEntityTypeConfiguration<ChiTietGioHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietGioHang> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.soLuong);
            builder.Property(c => c.trangThai);
            builder.HasOne(c => c.GioHang).WithMany(c => c.CChiTietGioHangs).HasForeignKey(c => c.idGioHang);
            builder.HasOne(c => c.Giay).WithMany(c => c.ChiTietGioHangs).HasForeignKey(c => c.idGiay);
        }
    }
}
