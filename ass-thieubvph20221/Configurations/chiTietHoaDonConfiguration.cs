using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class chiTietHoaDonConfiguration:IEntityTypeConfiguration<chiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<chiTietHoaDon> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.soLuong);
            builder.Property(c => c.donGia);
            builder.Property(c => c.giamGia);
            builder.Property(c => c.thanhTien);
            builder.HasOne(c => c.HoaDon).WithMany(c=>c.ChiTietHoaDons).HasForeignKey(c => c.idHoaDon);
            builder.HasOne(c => c.Giay).WithMany(c => c.ChiTietHoaDons).HasForeignKey(c => c.idGiay);

        }
    }
}
