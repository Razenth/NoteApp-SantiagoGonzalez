using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfiModuloMaestro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaestroVsSubmodulo_ModulosMaestros_IdMaestro",
                table: "MaestroVsSubmodulo");

            migrationBuilder.DropForeignKey(
                name: "FK_RolVsMaestro_ModulosMaestros_IdMaestro",
                table: "RolVsMaestro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulosMaestros",
                table: "ModulosMaestros");

            migrationBuilder.RenameTable(
                name: "ModulosMaestros",
                newName: "ModuloMaestro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "ModuloMaestro",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "ModuloMaestro",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloMaestro",
                table: "ModuloMaestro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroVsSubmodulo_ModuloMaestro_IdMaestro",
                table: "MaestroVsSubmodulo",
                column: "IdMaestro",
                principalTable: "ModuloMaestro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolVsMaestro_ModuloMaestro_IdMaestro",
                table: "RolVsMaestro",
                column: "IdMaestro",
                principalTable: "ModuloMaestro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaestroVsSubmodulo_ModuloMaestro_IdMaestro",
                table: "MaestroVsSubmodulo");

            migrationBuilder.DropForeignKey(
                name: "FK_RolVsMaestro_ModuloMaestro_IdMaestro",
                table: "RolVsMaestro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloMaestro",
                table: "ModuloMaestro");

            migrationBuilder.RenameTable(
                name: "ModuloMaestro",
                newName: "ModulosMaestros");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "ModulosMaestros",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "ModulosMaestros",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulosMaestros",
                table: "ModulosMaestros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroVsSubmodulo_ModulosMaestros_IdMaestro",
                table: "MaestroVsSubmodulo",
                column: "IdMaestro",
                principalTable: "ModulosMaestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolVsMaestro_ModulosMaestros_IdMaestro",
                table: "RolVsMaestro",
                column: "IdMaestro",
                principalTable: "ModulosMaestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
