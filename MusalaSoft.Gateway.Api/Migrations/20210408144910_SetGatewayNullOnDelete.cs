using Microsoft.EntityFrameworkCore.Migrations;

namespace MusalaSoft.GatewayApp.Api.Migrations
{
    public partial class SetGatewayNullOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GatewayId",
                table: "Devices",
                column: "GatewayId",
                principalTable: "Gateways",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
