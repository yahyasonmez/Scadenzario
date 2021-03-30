using Microsoft.EntityFrameworkCore.Migrations;

namespace Scadenzario.Migrations
{
    public partial class AddRelazioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scadenze_Beneficiari_beneficiarioIDBeneficiario",
                table: "Scadenze");

            migrationBuilder.DropIndex(
                name: "IX_Scadenze_beneficiarioIDBeneficiario",
                table: "Scadenze");

            migrationBuilder.DropColumn(
                name: "beneficiarioIDBeneficiario",
                table: "Scadenze");

            migrationBuilder.CreateIndex(
                name: "IX_Scadenze_IDBeneficiario",
                table: "Scadenze",
                column: "IDBeneficiario");

            migrationBuilder.AddForeignKey(
                name: "FK_Scadenze_Beneficiari_IDBeneficiario",
                table: "Scadenze",
                column: "IDBeneficiario",
                principalTable: "Beneficiari",
                principalColumn: "IDBeneficiario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scadenze_Beneficiari_IDBeneficiario",
                table: "Scadenze");

            migrationBuilder.DropIndex(
                name: "IX_Scadenze_IDBeneficiario",
                table: "Scadenze");

            migrationBuilder.AddColumn<int>(
                name: "beneficiarioIDBeneficiario",
                table: "Scadenze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scadenze_beneficiarioIDBeneficiario",
                table: "Scadenze",
                column: "beneficiarioIDBeneficiario");

            migrationBuilder.AddForeignKey(
                name: "FK_Scadenze_Beneficiari_beneficiarioIDBeneficiario",
                table: "Scadenze",
                column: "beneficiarioIDBeneficiario",
                principalTable: "Beneficiari",
                principalColumn: "IDBeneficiario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
