using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototype.Infra.Data.Migrations
{
    public partial class DescricaoCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 230, DateTimeKind.Local).AddTicks(1498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 5, 21, 0, 27, 783, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 223, DateTimeKind.Local).AddTicks(2625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 5, 21, 0, 27, 776, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Carrinho",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Carrinho");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 21, 0, 27, 783, DateTimeKind.Local).AddTicks(2348),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 230, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 21, 0, 27, 776, DateTimeKind.Local).AddTicks(5570),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 223, DateTimeKind.Local).AddTicks(2625));
        }
    }
}
