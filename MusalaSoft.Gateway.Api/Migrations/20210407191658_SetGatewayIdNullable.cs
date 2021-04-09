using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaSoft.GatewayApp.Api.Migrations
{
    public partial class SetGatewayIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "GatewayId",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "GatewayId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
