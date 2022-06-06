using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class adicionandorelaçãoentreGerenteeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "gerentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gerentes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cinemas_GerenteId",
                table: "cinemas",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas",
                column: "GerenteId",
                principalTable: "gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas");

            migrationBuilder.DropTable(
                name: "gerentes");

            migrationBuilder.DropIndex(
                name: "IX_cinemas_GerenteId",
                table: "cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "cinemas");
        }
    }
}
