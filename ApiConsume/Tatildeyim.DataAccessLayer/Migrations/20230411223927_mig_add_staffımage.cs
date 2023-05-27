using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tatildeyim.DataAccessLayer.Migrations
{
    public partial class mig_add_staffımage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Staffs");
        }
    }
}
