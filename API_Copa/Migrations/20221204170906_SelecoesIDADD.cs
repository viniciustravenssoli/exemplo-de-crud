using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Copa.Migrations
{
    public partial class SelecoesIDADD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos");

            migrationBuilder.AlterColumn<int>(
                name: "SelecaoBId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SelecaoAId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos");

            migrationBuilder.AlterColumn<int>(
                name: "SelecaoBId",
                table: "Jogos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SelecaoAId",
                table: "Jogos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
