using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiLivrosMeusDados.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Autores = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Editora = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeusDados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    RU = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Curso = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeusDados", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Ano", "Autores", "Cidade", "Editora", "Titulo" },
                values: new object[,]
                {
                    { 1, 2019, "LEDUR, Cleverson Lopes", "Porto Alegre", "SAGAH", "Programação Back End II" },
                    { 2, 2021, "FREITAS, Pedro H. Chagas [et al.]", "Porto Alegre", "SAGAH", "Programação Back End III" },
                    { 3, 2008, "DEITEL, Paul J.", "São Paulo", "Pearson Prentice Hall", "Ajax, RICH Internet Applications e desenvolvimento Web para programadores" }
                });

            migrationBuilder.InsertData(
                table: "MeusDados",
                columns: new[] { "Id", "Curso", "Nome", "RU" },
                values: new object[] { 1, "Analise e Desenvolvimento de Sistemas", "Roger de Oliveira Lima", "3842061" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "MeusDados");
        }
    }
}