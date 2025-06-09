using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class FinalBillAndServiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receptionists_UserID",
                table: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserID",
                table: "Admins");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bills_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Consultation", "Standard doctor consultation", "General Consultation", 50.00m },
                    { 2, "Consultation", "Specialist doctor consultation", "Specialist Consultation", 100.00m },
                    { 3, "Laboratory", "Complete blood count", "Blood Test", 30.00m },
                    { 4, "Imaging", "Standard X-Ray imaging", "X-Ray", 80.00m },
                    { 5, "Imaging", "Magnetic Resonance Imaging", "MRI Scan", 300.00m },
                    { 6, "Diagnostic", "Electrocardiogram", "ECG", 60.00m },
                    { 7, "Imaging", "Ultrasound examination", "Ultrasound", 120.00m },
                    { 8, "Treatment", "Standard vaccination", "Vaccination", 40.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_UserID",
                table: "Receptionists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserID",
                table: "Admins",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientID",
                table: "Bills",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Receptionists_UserID",
                table: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserID",
                table: "Admins");

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
        }
    }
}
