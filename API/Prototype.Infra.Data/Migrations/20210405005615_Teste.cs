using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototype.Infra.Data.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 46, DateTimeKind.Local).AddTicks(3820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 18, 42, 23, 167, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 30, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 18, 42, 23, 145, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tem_Promocao = table.Column<bool>(nullable: false, defaultValue: false),
                    Id_Promocao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Promocoes_Id_Promocao",
                        column: x => x.Id_Promocao,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Promocao",
                table: "Produtos",
                column: "Id_Promocao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Tramitacao",
                table: "Tramitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 18, 42, 23, 167, DateTimeKind.Local).AddTicks(1437),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 46, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ultima_Modificacao",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 18, 42, 23, 145, DateTimeKind.Local).AddTicks(4595),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 4, 21, 56, 15, 30, DateTimeKind.Local).AddTicks(2442));
        }
    }
}
