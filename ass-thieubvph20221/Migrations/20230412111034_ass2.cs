using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ass_thieubvph20221.Migrations
{
    public partial class ass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idNhanVien",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "idNhanVien",
                table: "GioHangs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idNhanVien",
                table: "HoaDons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idNhanVien",
                table: "GioHangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
