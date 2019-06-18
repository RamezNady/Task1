using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_API.Migrations
{
    public partial class MyFirs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Users",
                newName: "IsActive");
        }
    }
}
