using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaSoft.GatewayApp.Api.Migrations
{
    public partial class RemoveUniqueVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_Vendor",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "Vendor",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vendor",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Vendor",
                table: "Devices",
                column: "Vendor",
                unique: true,
                filter: "[Vendor] IS NOT NULL");
        }
    }
}
