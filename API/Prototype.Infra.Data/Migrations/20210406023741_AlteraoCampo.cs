using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototype.Infra.Data.Migrations
{
    public partial class AlteraoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 37, 41, 99, DateTimeKind.Local).AddTicks(4125),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 230, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Promocoes",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 37, 41, 92, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 223, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Carrinho",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 230, DateTimeKind.Local).AddTicks(1498),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 37, 41, 99, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Promocoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 5, 23, 32, 57, 223, DateTimeKind.Local).AddTicks(2625),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 5, 23, 37, 41, 92, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Carrinho",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
