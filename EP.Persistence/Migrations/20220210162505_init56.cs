using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP.Persistence.Migrations
{
    public partial class init56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IranStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IranStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IranStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cites_IranStates_IranStateId",
                        column: x => x.IranStateId,
                        principalTable: "IranStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IranStateId = table.Column<int>(type: "int", nullable: false),
                    IranCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_cites_IranCityId",
                        column: x => x.IranCityId,
                        principalTable: "cites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_IranStates_IranStateId",
                        column: x => x.IranStateId,
                        principalTable: "IranStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cites_IranStateId",
                table: "cites",
                column: "IranStateId");

            migrationBuilder.CreateIndex(
                name: "IX_People_IranCityId",
                table: "People",
                column: "IranCityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_IranStateId",
                table: "People",
                column: "IranStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "cites");

            migrationBuilder.DropTable(
                name: "IranStates");
        }
    }
}
