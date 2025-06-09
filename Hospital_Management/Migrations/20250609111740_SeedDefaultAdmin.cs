using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Receptionists",
                columns: new[] { "ReceptionistID", "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 1, "Admin", "srLxBNMsY4kD4VGpsg1uJ7QdjAyEz4RYc4+Dyi8d10Q=", "1234567890", "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1);
        }
    }
}
