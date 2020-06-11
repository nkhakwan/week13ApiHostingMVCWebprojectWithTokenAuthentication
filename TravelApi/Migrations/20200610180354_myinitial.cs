using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class myinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 1,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 2,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "KhanTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 1,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 2,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "HansaTest");
        }
    }
}
