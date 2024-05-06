using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcSistemaVentas.Data.Migrations
{
    /// <inheritdoc />
    public partial class primeram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "Venta");

            migrationBuilder.AddColumn<int>(
                name: "ClientelaId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClientelaId",
                table: "Venta",
                column: "ClientelaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_ClientelaId",
                table: "Venta",
                column: "ClientelaId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_ClientelaId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_ClientelaId",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "ClientelaId",
                table: "Venta");

            migrationBuilder.AddColumn<string>(
                name: "NroDocumento",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
