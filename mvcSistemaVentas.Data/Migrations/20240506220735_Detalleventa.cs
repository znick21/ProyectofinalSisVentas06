using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcSistemaVentas.Data.Migrations
{
    /// <inheritdoc />
    public partial class Detalleventa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "DetalleVenta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetalleVenta");
        }
    }
}
