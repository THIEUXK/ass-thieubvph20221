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
                    tenGiay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soLuong = table.Column<int>(type: "int", nullable: true),
                    chatLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donGiaNhap = table.Column<int>(type: "int", nullable: true),
                    donGiaban = table.Column<int>(type: "int", nullable: true),
                    anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    tenKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.id);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_idKhachHang",
                        column: x => x.idKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ngayBan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tongTien = table.Column<int>(type: "int", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHangs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    soLuong = table.Column<int>(type: "int", nullable: true),
                    trangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHangs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_Giays_idGiay",
                        column: x => x.idGiay,
                        principalTable: "Giays",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ChiTietGioHangs_GioHangs_idGioHang",
                        column: x => x.idGioHang,
                        principalTable: "GioHangs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    soLuong = table.Column<int>(type: "int", nullable: true),
                    giamGia = table.Column<int>(type: "int", nullable: true),
                    donGia = table.Column<int>(type: "int", nullable: true),
                    thanhTien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_Giays_idGiay",
                        column: x => x.idGiay,
                        principalTable: "Giays",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                        column: x => x.idHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_idGiay",
                table: "ChiTietGioHangs",
                column: "idGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_idGioHang",
                table: "ChiTietGioHangs",
                column: "idGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_idGiay",
                table: "ChiTietHoaDons",
                column: "idGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_idHoaDon",
                table: "ChiTietHoaDons",
                column: "idHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_idKhachHang",
                table: "GioHangs",
                column: "idKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_idKhachHang",
                table: "HoaDons",
                column: "idKhachHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietGioHangs");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "Giays");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
