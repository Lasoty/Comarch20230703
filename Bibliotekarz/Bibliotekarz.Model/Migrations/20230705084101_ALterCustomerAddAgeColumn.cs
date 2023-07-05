using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotekarz.Model.Migrations
{
    /// <inheritdoc />
    public partial class ALterCustomerAddAgeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Borrowers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Borrowers");
        }
    }
}
