using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ass_thieubvph20221.Migrations
{
    public partial class vv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_Giays_idGiay",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                table: "ChiTietHoaDons");

            migrationBuilder.AlterColumn<string>(
                name: "tenNV",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "sDT",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanViens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "gioiTinh",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "diaChi",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "tenKH",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "sDT",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "diaChi",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "tongTien",
                table: "HoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayBan",
                table: "HoaDons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "tenGiay",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "soLuong",
                table: "Giays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ghiChu",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "donGiaban",
                table: "Giays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "donGiaNhap",
                table: "Giays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "chatLieu",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "anh",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "thanhTien",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "soLuong",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "idHoaDon",
                table: "ChiTietHoaDons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "idGiay",
                table: "ChiTietHoaDons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "giamGia",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "donGia",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                    table.ForeignKey(
                        name: "FK_GioHangs_NhanViens_idNhanVien",
                        column: x => x.idNhanVien,
                        principalTable: "NhanViens",
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

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_idGiay",
                table: "ChiTietGioHangs",
                column: "idGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHangs_idGioHang",
                table: "ChiTietGioHangs",
                column: "idGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_idKhachHang",
                table: "GioHangs",
                column: "idKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_idNhanVien",
                table: "GioHangs",
                column: "idNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_Giays_idGiay",
                table: "ChiTietHoaDons",
                column: "idGiay",
                principalTable: "Giays",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                table: "ChiTietHoaDons",
                column: "idHoaDon",
                principalTable: "HoaDons",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_Giays_idGiay",
                table: "ChiTietHoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                table: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ChiTietGioHangs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.AlterColumn<string>(
                name: "tenNV",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sDT",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanViens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gioiTinh",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "diaChi",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tenKH",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sDT",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "diaChi",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tongTien",
                table: "HoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayBan",
                table: "HoaDons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tenGiay",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "soLuong",
                table: "Giays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ghiChu",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "donGiaban",
                table: "Giays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "donGiaNhap",
                table: "Giays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "chatLieu",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "anh",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "thanhTien",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "soLuong",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "idHoaDon",
                table: "ChiTietHoaDons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "idGiay",
                table: "ChiTietHoaDons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "giamGia",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "donGia",
                table: "ChiTietHoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_Giays_idGiay",
                table: "ChiTietHoaDons",
                column: "idGiay",
                principalTable: "Giays",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_HoaDons_idHoaDon",
                table: "ChiTietHoaDons",
                column: "idHoaDon",
                principalTable: "HoaDons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
