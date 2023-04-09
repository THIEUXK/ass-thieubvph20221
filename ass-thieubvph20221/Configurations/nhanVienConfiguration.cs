using ass_thieubvph20221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ass_thieubvph20221.Configurations
{
    public class nhanVienConfiguration:IEntityTypeConfiguration<nhanVien>
    {
        public void Configure(EntityTypeBuilder<nhanVien> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.tenNV);
            builder.Property(c => c.gioiTinh);
            builder.Property(c => c.diaChi);
            builder.Property(c => c.sDT);
            builder.Property(c => c.ngaySinh);
            

        }
    }
}
