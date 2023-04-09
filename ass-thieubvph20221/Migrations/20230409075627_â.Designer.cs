﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ass_thieubvph20221.Models;

#nullable disable

namespace ass_thieubvph20221.Migrations
{
    [DbContext(typeof(giayDBcontext))]
    [Migration("20230409075627_â")]
    partial class â
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ass_thieubvph20221.Models.chiTietHoaDon", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("donGia")
                        .HasColumnType("int");

                    b.Property<int>("giamGia")
                        .HasColumnType("int");

                    b.Property<Guid>("idGiay")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idHoaDon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("soLuong")
                        .HasColumnType("int");

                    b.Property<int>("thanhTien")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idGiay");

                    b.HasIndex("idHoaDon");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.giay", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("anh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chatLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("donGiaNhap")
                        .HasColumnType("int");

                    b.Property<int>("donGiaban")
                        .HasColumnType("int");

                    b.Property<string>("ghiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soLuong")
                        .HasColumnType("int");

                    b.Property<string>("tenGiay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Giays");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.hoaDon", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idKhachHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idNhanVien")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ngayBan")
                        .HasColumnType("datetime2");

                    b.Property<int>("tongTien")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idKhachHang");

                    b.HasIndex("idNhanVien");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.khachHang", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.nhanVien", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("sDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenNV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.chiTietHoaDon", b =>
                {
                    b.HasOne("ass_thieubvph20221.Models.giay", "Giay")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("idGiay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ass_thieubvph20221.Models.hoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("idHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Giay");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.hoaDon", b =>
                {
                    b.HasOne("ass_thieubvph20221.Models.khachHang", "KhachHang")
                        .WithMany("HoaDon")
                        .HasForeignKey("idKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ass_thieubvph20221.Models.nhanVien", "NhanVien")
                        .WithMany("HoaDon")
                        .HasForeignKey("idNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.giay", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.hoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.khachHang", b =>
                {
                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("ass_thieubvph20221.Models.nhanVien", b =>
                {
                    b.Navigation("HoaDon");
                });
#pragma warning restore 612, 618
        }
    }
}
