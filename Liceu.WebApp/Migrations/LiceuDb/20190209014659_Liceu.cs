using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liceu.WebApp.Migrations.LiceuDb
{
    public partial class Liceu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GE_LIVRO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(nullable: false),
                    TITULO = table.Column<string>(maxLength: 50, nullable: false),
                    ANO_LANCAMENTO = table.Column<int>(maxLength: 4, nullable: false),
                    NOME_AUTOR = table.Column<string>(maxLength: 30, nullable: false),
                    NOME_EDITORA = table.Column<string>(maxLength: 50, nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GE_LIVRO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GE_LIVRO");
        }
    }
}
