using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangntPH30138.Migrations
{
    public partial class hahah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToaNhas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToaNhas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CanHos",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<double>(type: "float", nullable: false),
                    So = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToaNhaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanHos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CanHos_ToaNhas_ToaNhaID",
                        column: x => x.ToaNhaID,
                        principalTable: "ToaNhas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanHos_ToaNhaID",
                table: "CanHos",
                column: "ToaNhaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanHos");

            migrationBuilder.DropTable(
                name: "ToaNhas");
        }
    }
}
