using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class giayConfiguration:IEntityTypeConfiguration<giay>
    {
        public void Configure(EntityTypeBuilder<giay> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.tenGiay);
            builder.Property(c => c.chatLieu);
            builder.Property(c => c.soLuong);
            builder.Property(c => c.donGiaNhap);
            builder.Property(c => c.donGiaban);
            builder.Property(c => c.anh);
            builder.Property(c => c.ghiChu);

        }
    }
}
