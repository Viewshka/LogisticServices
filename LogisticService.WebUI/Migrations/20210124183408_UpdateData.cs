using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticService.WebUI.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b31f4aa-f01e-42d3-9b00-cfdbeb725bb0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "28d7a7a8-4779-47c4-b092-cb0369930a22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8d2a0c0a-24f3-4fd5-906f-525097e98766");

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Description", "FullName", "ShortName" },
                values: new object[] { 5, "Кубический метр", "Кубический метр", "куб. м" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "dc60015c-a7c7-4dbc-983c-b6ea774bb62e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d7bf5ba-79b2-453d-9447-598afe405467");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "bfc98cff-916b-4305-a831-6534b6a6626f");
        }
    }
}
