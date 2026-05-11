using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiSyncAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasLogisticas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasLogisticas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosNormalizados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosNormalizados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosOriginales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaLogisticaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosOriginales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadosOriginales_EmpresasLogisticas_EmpresaLogisticaId",
                        column: x => x.EmpresaLogisticaId,
                        principalTable: "EmpresasLogisticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaLogisticaId = table.Column<int>(type: "int", nullable: false),
                    EstadoOriginalId = table.Column<int>(type: "int", nullable: false),
                    EstadoNormalizadoId = table.Column<int>(type: "int", nullable: true),
                    Evidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envios_EmpresasLogisticas_EmpresaLogisticaId",
                        column: x => x.EmpresaLogisticaId,
                        principalTable: "EmpresasLogisticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Envios_EstadosNormalizados_EstadoNormalizadoId",
                        column: x => x.EstadoNormalizadoId,
                        principalTable: "EstadosNormalizados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Envios_EstadosOriginales_EstadoOriginalId",
                        column: x => x.EstadoOriginalId,
                        principalTable: "EstadosOriginales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TraduccionesEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoOriginalId = table.Column<int>(type: "int", nullable: false),
                    EstadoNormalizadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraduccionesEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraduccionesEstados_EstadosNormalizados_EstadoNormalizadoId",
                        column: x => x.EstadoNormalizadoId,
                        principalTable: "EstadosNormalizados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraduccionesEstados_EstadosOriginales_EstadoOriginalId",
                        column: x => x.EstadoOriginalId,
                        principalTable: "EstadosOriginales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envios_EmpresaLogisticaId",
                table: "Envios",
                column: "EmpresaLogisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_EstadoNormalizadoId",
                table: "Envios",
                column: "EstadoNormalizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_EstadoOriginalId",
                table: "Envios",
                column: "EstadoOriginalId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosOriginales_EmpresaLogisticaId",
                table: "EstadosOriginales",
                column: "EmpresaLogisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_TraduccionesEstados_EstadoNormalizadoId",
                table: "TraduccionesEstados",
                column: "EstadoNormalizadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TraduccionesEstados_EstadoOriginalId",
                table: "TraduccionesEstados",
                column: "EstadoOriginalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "TraduccionesEstados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EstadosNormalizados");

            migrationBuilder.DropTable(
                name: "EstadosOriginales");

            migrationBuilder.DropTable(
                name: "EmpresasLogisticas");
        }
    }
}
