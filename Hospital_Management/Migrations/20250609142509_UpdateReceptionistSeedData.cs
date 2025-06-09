using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceptionistSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                column: "FullName",
                value: "RoZaldo");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                column: "FullName",
                value: "Helena");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "RoZaldo", "a4ayc/80/OGda4BO/1o/V0etpOqiLx1JwB5S3beHW0s=", "aldo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Helena", "cQR0GpLnPrbF1pzQTPCvvlCoeWoBDY+iXar3nl4XO/M=", "helena" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                column: "FullName",
                value: "Dardan Hoxha");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                column: "FullName",
                value: "Ermal Berisha");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Dardan Hoxha", "dhlTxDIicEh9sehdrRb2CnDbwGZeE3IL8RCRc6oULNs=", "Dardan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Ermal Berisha", "oIKDar/IMv5mWrze5EMPA8Fq7U/zQqAlG4n/w6ArEMs=", "Ermal" });
        }
    }
}
