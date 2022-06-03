using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class Relacionandocinemaeendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Diretor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Genero = table.Column<string>(type: "text", nullable: true),
                    ClassificacaoEtaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cinemas_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cinemas_EnderecoId",
                table: "cinemas",
                column: "EnderecoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cinemas");

            migrationBuilder.DropTable(
                name: "filmes");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
