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
                name: "idChatLieu",
                table: "Giays");

            migrationBuilder.AddColumn<string>(
                name: "chatLieu",
                table: "Giays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chatLieu",
                table: "Giays");

            migrationBuilder.AddColumn<Guid>(
                name: "idChatLieu",
                table: "Giays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
