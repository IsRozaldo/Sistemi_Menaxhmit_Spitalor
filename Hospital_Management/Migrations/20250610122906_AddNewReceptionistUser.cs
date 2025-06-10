using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddNewReceptionistUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 4, "Ina", "vKw3G1T1mUWhSqSeLkCOXW5NvFk4f12M/GsBXUDVuwI=", "0689078456", "Receptionist", "ina" });

            migrationBuilder.InsertData(
                table: "Receptionists",
                columns: new[] { "ReceptionistID", "FullName", "PhoneNumber", "UserID" },
                values: new object[] { 3, "Ina", "0689078456", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);
        }
    }
}
