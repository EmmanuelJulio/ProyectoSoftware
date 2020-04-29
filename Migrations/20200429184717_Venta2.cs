using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSoftware.Migrations
{
    public partial class Venta2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Clientes_ClienteId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Productos_ProductoId",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Venta",
                newName: "ClienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                newName: "IX_Venta_ClienteID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Venta",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Venta",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Clientes_ClienteID",
                table: "Venta",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Productos_ProductoId",
                table: "Venta",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Clientes_ClienteID",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Productos_ProductoId",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Venta",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_ClienteID",
                table: "Venta",
                newName: "IX_Venta_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Clientes_ClienteId",
                table: "Venta",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Productos_ProductoId",
                table: "Venta",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
