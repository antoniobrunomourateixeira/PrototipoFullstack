using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototype.Infra.Data.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_Id_Promocao",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Id_Promocao",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 57, 18, 532, DateTimeKind.Local).AddTicks(9385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 46, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_Promocao",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 57, 18, 516, DateTimeKind.Local).AddTicks(1184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 30, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Promocao",
                table: "Produtos",
                column: "Id_Promocao",
                unique: true,
                filter: "[Id_Promocao] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_Id_Promocao",
                table: "Produtos",
                column: "Id_Promocao",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_Id_Promocao",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Id_Promocao",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 46, DateTimeKind.Local).AddTicks(3820),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 57, 18, 532, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_Promocao",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 30, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 57, 18, 516, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Promocao",
                table: "Produtos",
                column: "Id_Promocao",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_Id_Promocao",
                table: "Produtos",
                column: "Id_Promocao",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
