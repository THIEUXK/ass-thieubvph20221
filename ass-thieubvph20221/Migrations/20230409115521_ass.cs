using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ass_thieubvph20221.Migrations
{
    public partial class ass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giays",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenGiay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chatLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    donGiaNhap = table.Column<int>(type: "int", nullable: false),
                    donGiaban = table.Column<int>(type: "int", nullable: false),
                    anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ngayBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tongTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_idKhachHang",
                        column: x => x.idKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_idNhanVien",
                        column: x => x.idNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    donGia = table.Column<int>(type: "int", nullable: false),
                    giamGia = table.Column<int>(type: "int", nullable: false),
                    thanhTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_Giays_idGiay",
                        column: x => x.idGiay,
                        principalTable: "Giays",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                        column: x => x.idHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_idGiay",
                table: "ChiTietHoaDons",
                column: "idGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_idHoaDon",
                table: "ChiTietHoaDons",
                column: "idHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_idKhachHang",
                table: "HoaDons",
                column: "idKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_idNhanVien",
                table: "HoaDons",
                column: "idNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "Giays");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
