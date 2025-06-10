using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneNumbersToStartWith06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "0612345678");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "0698765432");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                column: "PhoneNumber",
                value: "0655555555");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "0612345678");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "PhoneNumber",
                value: "0698765432");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                column: "PhoneNumber",
                value: "0655555555");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "9876543210");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                column: "PhoneNumber",
                value: "5555555555");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "PhoneNumber",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "PhoneNumber",
                value: "9876543210");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                column: "PhoneNumber",
                value: "5555555555");
        }
    }
}
