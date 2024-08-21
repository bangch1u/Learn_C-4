using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_AssFinal_05.Migrations
{
    public partial class hahah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocs", x => x.MaKhoaHoc);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    khoaHocMaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocViens_khoaHocs_khoaHocMaKhoaHoc",
                        column: x => x.khoaHocMaKhoaHoc,
                        principalTable: "khoaHocs",
                        principalColumn: "MaKhoaHoc");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocViens_khoaHocMaKhoaHoc",
                table: "HocViens",
                column: "khoaHocMaKhoaHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "khoaHocs");
        }
    }
}
