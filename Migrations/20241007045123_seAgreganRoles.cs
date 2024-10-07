using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechStore.Migrations
{
    /// <inheritdoc />
    public partial class seAgreganRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 4, "Ventas" },
                    { 5, "Atención al cliente" },
                    { 6, "Inventario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
