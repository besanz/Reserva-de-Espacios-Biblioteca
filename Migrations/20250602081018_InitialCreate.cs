using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reserva_de_Espacios_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cabinas",
                columns: new[] { "Id", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Cabina Individual" },
                    { 2, 4, "Cabina Grupal" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "CabinaId", "Fin", "Inicio", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 6, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2025, 6, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, new DateTime(2025, 6, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, new DateTime(2025, 6, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 2, new DateTime(2025, 6, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 1, new DateTime(2025, 6, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 2, new DateTime(2025, 6, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 1, new DateTime(2025, 6, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 2, new DateTime(2025, 6, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Dni", "Email", "EstaActivo", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez García", "12345678A", "juan.perez@ejemplo.com", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "612345678" },
                    { 2, "López Sánchez", "87654321B", "maria.lopez@ejemplo.com", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "687654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cabinas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
