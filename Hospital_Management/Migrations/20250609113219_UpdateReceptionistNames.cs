using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceptionistNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Arlind Krasniqi", "UdveFgzgF8aPmz9H0Pjn73Jtmi+xbFms9WimaqP8ny4=", "Arlind" });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Dardan Hoxha", "dhlTxDIicEh9sehdrRb2CnDbwGZeE3IL8RCRc6oULNs=", "Dardan" });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 3,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Ermal Berisha", "oIKDar/IMv5mWrze5EMPA8Fq7U/zQqAlG4n/w6ArEMs=", "Ermal" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Admin", "srLxBNMsY4kD4VGpsg1uJ7QdjAyEz4RYc4+Dyi8d10Q=", "Admin" });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "John Doe", "NwQg4zX3pNLq1oeZkWQXktW9zeLbXU+uPZdsITNzLNo=", "John" });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 3,
                columns: new[] { "FullName", "Password", "Username" },
                values: new object[] { "Jane Smith", "o1MrwZedNj+25SMqcanmm39cD1rE4Sqf4KAGFPn0tQM=", "Jane" });
        }
    }
}
