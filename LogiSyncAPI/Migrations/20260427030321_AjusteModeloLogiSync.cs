using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiSyncAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModeloLogiSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_EstadosNormalizados_EstadoNormalizadoId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadosOriginales_EmpresasLogisticas_EmpresaLogisticaId",
                table: "EstadosOriginales");

            migrationBuilder.DropForeignKey(
                name: "FK_TraduccionesEstados_EstadosNormalizados_EstadoNormalizadoId",
                table: "TraduccionesEstados");

            migrationBuilder.DropForeignKey(
                name: "FK_TraduccionesEstados_EstadosOriginales_EstadoOriginalId",
                table: "TraduccionesEstados");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "Evidencia",
                table: "Envios");

            migrationBuilder.CreateTable(
                name: "Evidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvioId = table.Column<int>(type: "int", nullable: false),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidencias_Envios_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvioId = table.Column<int>(type: "int", nullable: false),
                    EstadoOriginalId = table.Column<int>(type: "int", nullable: false),
                    EstadoNormalizadoId = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialEstados_Envios_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialEstados_EstadosNormalizados_EstadoNormalizadoId",
                        column: x => x.EstadoNormalizadoId,
                        principalTable: "EstadosNormalizados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialEstados_EstadosOriginales_EstadoOriginalId",
                        column: x => x.EstadoOriginalId,
                        principalTable: "EstadosOriginales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidencias_EnvioId",
                table: "Evidencias",
                column: "EnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstados_EnvioId",
                table: "HistorialEstados",
                column: "EnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstados_EstadoNormalizadoId",
                table: "HistorialEstados",
                column: "EstadoNormalizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstados_EstadoOriginalId",
                table: "HistorialEstados",
                column: "EstadoOriginalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_EstadosNormalizados_EstadoNormalizadoId",
                table: "Envios",
                column: "EstadoNormalizadoId",
                principalTable: "EstadosNormalizados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosOriginales_EmpresasLogisticas_EmpresaLogisticaId",
                table: "EstadosOriginales",
                column: "EmpresaLogisticaId",
                principalTable: "EmpresasLogisticas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TraduccionesEstados_EstadosNormalizados_EstadoNormalizadoId",
                table: "TraduccionesEstados",
                column: "EstadoNormalizadoId",
                principalTable: "EstadosNormalizados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TraduccionesEstados_EstadosOriginales_EstadoOriginalId",
                table: "TraduccionesEstados",
                column: "EstadoOriginalId",
                principalTable: "EstadosOriginales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_EstadosNormalizados_EstadoNormalizadoId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadosOriginales_EmpresasLogisticas_EmpresaLogisticaId",
                table: "EstadosOriginales");

            migrationBuilder.DropForeignKey(
                name: "FK_TraduccionesEstados_EstadosNormalizados_EstadoNormalizadoId",
                table: "TraduccionesEstados");

            migrationBuilder.DropForeignKey(
                name: "FK_TraduccionesEstados_EstadosOriginales_EstadoOriginalId",
                table: "TraduccionesEstados");

            migrationBuilder.DropTable(
                name: "Evidencias");

            migrationBuilder.DropTable(
                name: "HistorialEstados");

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Evidencia",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_EstadosNormalizados_EstadoNormalizadoId",
                table: "Envios",
                column: "EstadoNormalizadoId",
                principalTable: "EstadosNormalizados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosOriginales_EmpresasLogisticas_EmpresaLogisticaId",
                table: "EstadosOriginales",
                column: "EmpresaLogisticaId",
                principalTable: "EmpresasLogisticas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraduccionesEstados_EstadosNormalizados_EstadoNormalizadoId",
                table: "TraduccionesEstados",
                column: "EstadoNormalizadoId",
                principalTable: "EstadosNormalizados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraduccionesEstados_EstadosOriginales_EstadoOriginalId",
                table: "TraduccionesEstados",
                column: "EstadoOriginalId",
                principalTable: "EstadosOriginales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
