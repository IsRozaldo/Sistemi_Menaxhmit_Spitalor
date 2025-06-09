using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserAndAdminTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Receptionists");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Receptionists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                columns: new[] { "FullName", "PhoneNumber", "UserID" },
                values: new object[] { "Dardan Hoxha", "9876543210", 2 });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                columns: new[] { "FullName", "PhoneNumber", "UserID" },
                values: new object[] { "Ermal Berisha", "5555555555", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Arlind Krasniqi", "UdveFgzgF8aPmz9H0Pjn73Jtmi+xbFms9WimaqP8ny4=", "1234567890", "Admin", "Arlind" },
                    { 2, "Dardan Hoxha", "dhlTxDIicEh9sehdrRb2CnDbwGZeE3IL8RCRc6oULNs=", "9876543210", "Receptionist", "Dardan" },
                    { 3, "Ermal Berisha", "oIKDar/IMv5mWrze5EMPA8Fq7U/zQqAlG4n/w6ArEMs=", "5555555555", "Receptionist", "Ermal" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminID", "FullName", "PhoneNumber", "UserID" },
                values: new object[] { 1, "Arlind Krasniqi", "1234567890", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_UserID",
                table: "Receptionists",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserID",
                table: "Admins",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Users_UserID",
                table: "Receptionists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Users_UserID",
                table: "Receptionists");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Receptionists_UserID",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Receptionists");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { "Arlind Krasniqi", "UdveFgzgF8aPmz9H0Pjn73Jtmi+xbFms9WimaqP8ny4=", "1234567890", "Admin", "Arlind" });

            migrationBuilder.UpdateData(
                table: "Receptionists",
                keyColumn: "ReceptionistID",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { "Dardan Hoxha", "dhlTxDIicEh9sehdrRb2CnDbwGZeE3IL8RCRc6oULNs=", "9876543210", "Receptionist", "Dardan" });

            migrationBuilder.InsertData(
                table: "Receptionists",
                columns: new[] { "ReceptionistID", "FullName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[] { 3, "Ermal Berisha", "oIKDar/IMv5mWrze5EMPA8Fq7U/zQqAlG4n/w6ArEMs=", "5555555555", "Receptionist", "Ermal" });
        }
    }
}
