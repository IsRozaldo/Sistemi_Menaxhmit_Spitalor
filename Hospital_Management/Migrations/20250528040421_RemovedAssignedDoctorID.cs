using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAssignedDoctorID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDoctorID",
                table: "Patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedDoctorID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
