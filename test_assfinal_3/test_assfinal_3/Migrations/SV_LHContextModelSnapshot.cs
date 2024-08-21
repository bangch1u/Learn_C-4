﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_assfinal_3.Models;

#nullable disable

namespace test_assfinal_3.Migrations
{
    [DbContext(typeof(SV_LHContext))]
    partial class SV_LHContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("test_assfinal_3.Models.LopHoc", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Khoa")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLop");

                    b.ToTable("LopHocs");
                });

            modelBuilder.Entity("test_assfinal_3.Models.SinhVien", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LopHocMaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LopHocMaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("test_assfinal_3.Models.SinhVien", b =>
                {
                    b.HasOne("test_assfinal_3.Models.LopHoc", "LopHoc")
                        .WithMany("SinhViens")
                        .HasForeignKey("LopHocMaLop");

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("test_assfinal_3.Models.LopHoc", b =>
                {
                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
