using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSoftware.Migrations
{
    public partial class Venta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fechadeactualizaion",
                table: "Venta");

            migrationBuilder.AddColumn<int>(
                name: "ClienteNavigatorId",
                table: "Venta",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechadeactualizaion2",
                table: "Venta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductoNavigatorId",
                table: "Venta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteNavigatorId",
                table: "Venta",
                column: "ClienteNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ProductoNavigatorId",
                table: "Venta",
                column: "ProductoNavigatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Clientes_ClienteNavigatorId",
                table: "Venta",
                column: "ClienteNavigatorId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Productos_ProductoNavigatorId",
                table: "Venta",
                column: "ProductoNavigatorId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Clientes_ClienteNavigatorId",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Productos_ProductoNavigatorId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_ClienteNavigatorId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_ProductoNavigatorId",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "ClienteNavigatorId",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "Fechadeactualizaion2",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "ProductoNavigatorId",
                table: "Venta");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechadeactualizaion",
                table: "Venta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
