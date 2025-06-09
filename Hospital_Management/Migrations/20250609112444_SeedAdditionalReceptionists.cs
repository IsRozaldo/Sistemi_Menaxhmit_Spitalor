using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalReceptionists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Receptionists",
                columns: new[] { "ReceptionistID", "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 2, "John Doe", "NwQg4zX3pNLq1oeZkWQXktW9zeLbXU+uPZdsITNzLNo=", "9876543210", "Receptionist", "John" },
                    { 3, "Jane Smith", "o1MrwZedNj+25SMqcanmm39cD1rE4Sqf4KAGFPn0tQM=", "5555555555", "Receptionist", "Jane" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 3);
        }
    }
}
