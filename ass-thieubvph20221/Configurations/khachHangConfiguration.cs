using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class khachHangConfiguration:IEntityTypeConfiguration<khachHang>
    {
        public void Configure(EntityTypeBuilder<khachHang> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.tenKH);
            builder.Property(c => c.diaChi);
            builder.Property(c => c.sDT);
            builder.Property(c => c.ChucVu);
        }
    }
}
