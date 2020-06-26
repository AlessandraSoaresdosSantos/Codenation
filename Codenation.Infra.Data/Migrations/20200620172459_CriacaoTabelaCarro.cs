using Microsoft.EntityFrameworkCore.Migrations;

namespace Codenation.Infra.Data.Migrations
{
    public partial class CriacaoTabelaCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    MarcaID = table.Column<int>(nullable: true),
                    ModeloID = table.Column<int>(nullable: true),
                    VersaoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Carro_Marca_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carro_Modelo_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carro_Versao_VersaoID",
                        column: x => x.VersaoID,
                        principalTable: "Versao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_MarcaID",
                table: "Carro",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ModeloID",
                table: "Carro",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Carro_VersaoID",
                table: "Carro",
                column: "VersaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carro");
        }
    }
}
