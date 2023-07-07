using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NationalParksApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "Activities", "Description", "ParkName", "State" },
                values: new object[,]
                {
                    { 1, "Hiking, Wildlife Viewing, Camping", "First national park in the world.", "Yellowstone", "Wyoming" },
                    { 2, "Hiking, Rock Climbing, Camping", "Famous for its waterfalls.", "Yosemite", "California" },
                    { 3, "Hiking, Rafting, Helicopter Tours", "Known for its visually overwhelming size.", "Grand Canyon", "Arizona" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
