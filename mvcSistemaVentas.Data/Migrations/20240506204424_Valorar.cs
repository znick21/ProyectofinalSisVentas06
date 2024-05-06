using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcSistemaVentas.Data.Migrations
{
    /// <inheritdoc />
    public partial class Valorar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "PrecioVenta",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Compra");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Venta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Venta",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Proveedor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Producto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCaducidad",
                table: "Producto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "DetalleVenta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DetalleVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "DetalleVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "DetalleCompra",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "DetalleCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DetalleCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Compra",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Compra",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ProductoId",
                table: "DetalleVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaId",
                table: "DetalleVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_CompraId",
                table: "DetalleCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_ProductoId",
                table: "DetalleCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdUsuario",
                table: "Compra",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProveedorId",
                table: "Compra",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_IdUsuario",
                table: "Compra",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Proveedor_ProveedorId",
                table: "Compra",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Compra_CompraId",
                table: "DetalleCompra",
                column: "CompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Producto_ProductoId",
                table: "DetalleCompra",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Producto_ProductoId",
                table: "DetalleVenta",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta",
                column: "VentaId",
                principalTable: "Venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_AspNetUsers_IdUsuario",
                table: "Venta",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_IdUsuario",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Proveedor_ProveedorId",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Compra_CompraId",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Producto_ProductoId",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Producto_ProductoId",
                table: "DetalleVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_AspNetUsers_IdUsuario",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVenta_ProductoId",
                table: "DetalleVenta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVenta_VentaId",
                table: "DetalleVenta");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_CompraId",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_ProductoId",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdUsuario",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ProveedorId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Cliente");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "Venta",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DocumentoCliente",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "Producto",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaCaducidad",
                table: "Producto",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "DetalleVenta",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "DetalleVenta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "DetalleCompra",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCompra",
                table: "DetalleCompra",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVenta",
                table: "DetalleCompra",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "Compra",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Compra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Compra",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
