using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NuevasEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuloMaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloMaestro", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisoGenerico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePermiso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoGenerico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Submodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubmodulo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodulo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolVsMaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolVsMaestro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_ModuloMaestro_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModuloMaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaestroVsSubmodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    IdSubmodulo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroVsSubmodulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestroVsSubmodulo_ModuloMaestro_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModuloMaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestroVsSubmodulo_Submodulo_IdSubmodulo",
                        column: x => x.IdSubmodulo,
                        principalTable: "Submodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenericoVsSubmodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdGenericos = table.Column<int>(type: "int", nullable: false),
                    IdSubmodulos = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericoVsSubmodulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericoVsSubmodulo_MaestroVsSubmodulo_IdSubmodulos",
                        column: x => x.IdSubmodulos,
                        principalTable: "MaestroVsSubmodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericoVsSubmodulo_PermisoGenerico_IdGenericos",
                        column: x => x.IdGenericos,
                        principalTable: "PermisoGenerico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericoVsSubmodulo_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GenericoVsSubmodulo_IdGenericos",
                table: "GenericoVsSubmodulo",
                column: "IdGenericos");

            migrationBuilder.CreateIndex(
                name: "IX_GenericoVsSubmodulo_IdRol",
                table: "GenericoVsSubmodulo",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_GenericoVsSubmodulo_IdSubmodulos",
                table: "GenericoVsSubmodulo",
                column: "IdSubmodulos");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroVsSubmodulo_IdMaestro",
                table: "MaestroVsSubmodulo",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroVsSubmodulo_IdSubmodulo",
                table: "MaestroVsSubmodulo",
                column: "IdSubmodulo");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdMaestro",
                table: "RolVsMaestro",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdRol",
                table: "RolVsMaestro",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericoVsSubmodulo");

            migrationBuilder.DropTable(
                name: "RolVsMaestro");

            migrationBuilder.DropTable(
                name: "MaestroVsSubmodulo");

            migrationBuilder.DropTable(
                name: "PermisoGenerico");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "ModuloMaestro");

            migrationBuilder.DropTable(
                name: "Submodulo");
        }
    }
}
