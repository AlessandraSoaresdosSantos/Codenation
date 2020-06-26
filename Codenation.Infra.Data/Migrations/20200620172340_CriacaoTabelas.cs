using Microsoft.EntityFrameworkCore.Migrations;

namespace Codenation.Infra.Data.Migrations
{
    public partial class CriacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    MarcaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    ModeloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Versao_Modelo_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<string>(type: "varchar(500)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    AnoModelo = table.Column<int>(type: "int", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "varchar(500)", nullable: false),
                    MarcaID = table.Column<int>(nullable: true),
                    ModeloID = table.Column<int>(nullable: true),
                    VersaoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Veiculo_Marca_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculo_Modelo_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculo_Versao_VersaoID",
                        column: x => x.VersaoID,
                        principalTable: "Versao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaID",
                table: "Modelo",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_MarcaID",
                table: "Veiculo",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ModeloID",
                table: "Veiculo",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_VersaoID",
                table: "Veiculo",
                column: "VersaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Versao_ModeloID",
                table: "Versao",
                column: "ModeloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Versao");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
