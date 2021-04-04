using Microsoft.EntityFrameworkCore.Migrations;

namespace Scadenzario.Migrations
{
    public partial class AddDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scadenze_Beneficiari_IDBeneficiario",
                table: "Scadenze");

            migrationBuilder.AlterColumn<decimal>(
                name: "Importo",
                table: "Scadenze",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Ricevute",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddForeignKey(
                name: "FK_Scadenze_Beneficiario",
                table: "Scadenze",
                column: "IDBeneficiario",
                principalTable: "Beneficiari",
                principalColumn: "IDBeneficiario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scadenze_Beneficiario",
                table: "Scadenze");

            migrationBuilder.AlterColumn<decimal>(
                name: "Importo",
                table: "Scadenze",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Ricevute",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddForeignKey(
                name: "FK_Scadenze_Beneficiari_IDBeneficiario",
                table: "Scadenze",
                column: "IDBeneficiario",
                principalTable: "Beneficiari",
                principalColumn: "IDBeneficiario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
