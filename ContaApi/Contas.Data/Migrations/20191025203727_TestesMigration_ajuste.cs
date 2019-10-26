using Microsoft.EntityFrameworkCore.Migrations;

namespace Contas.Data.Migrations
{
    public partial class TestesMigration_ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Lancamento_LancamentoId",
                table: "Conta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_LancamentoId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "LancamentoId",
                table: "Conta");

            migrationBuilder.AddColumn<int>(
                name: "ContaDestinoId",
                table: "Lancamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaOrigemId",
                table: "Lancamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContaDestinoId",
                table: "Lancamento",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContaOrigemId",
                table: "Lancamento",
                column: "ContaOrigemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Conta_ContaDestinoId",
                table: "Lancamento",
                column: "ContaDestinoId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Conta_ContaOrigemId",
                table: "Lancamento",
                column: "ContaOrigemId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Conta_ContaDestinoId",
                table: "Lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Conta_ContaOrigemId",
                table: "Lancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamento_ContaDestinoId",
                table: "Lancamento");

            migrationBuilder.DropIndex(
                name: "IX_Lancamento_ContaOrigemId",
                table: "Lancamento");

            migrationBuilder.DropColumn(
                name: "ContaDestinoId",
                table: "Lancamento");

            migrationBuilder.DropColumn(
                name: "ContaOrigemId",
                table: "Lancamento");

            migrationBuilder.AddColumn<int>(
                name: "LancamentoId",
                table: "Conta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_LancamentoId",
                table: "Conta",
                column: "LancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Lancamento_LancamentoId",
                table: "Conta",
                column: "LancamentoId",
                principalTable: "Lancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
