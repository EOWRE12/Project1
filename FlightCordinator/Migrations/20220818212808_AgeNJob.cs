using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightCordinator.Migrations
{
    public partial class AgeNJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "Passengers");
        }
    }
}
