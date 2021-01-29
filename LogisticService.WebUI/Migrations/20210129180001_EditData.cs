using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticService.WebUI.Migrations
{
    public partial class EditData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d2786050-256e-41cd-9f23-e75c703961d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c6af4f5c-96c9-4f9f-aaab-ea43fd943397");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b36daefa-c5fd-4417-b59f-c723615551b9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "1d59920f-1207-477f-9c24-c64266e727d1", null, true, true, null, null, "MANAGER", "AQAAAAEAACcQAAAAEMAcG9aqAsgDomDamVgIWoCSo/BQp0aiYGlviJqK1PqZhWGpkzeCtgR9TTKEsXICMQ==", null, false, "c619a5df-646a-497a-ae2e-848f88025dcb", false, "Manager" },
                    { 2, 0, "385ed5ad-3d77-418f-b75f-b94360b8920d", null, true, true, null, null, "CLIENT", "AQAAAAEAACcQAAAAEPAOlYKrhZPVuQK5o0RhGQe0FoTGemJdgHbXw31YiWC+j6ivrRTe5cDNH7JIS8Arpg==", null, false, "1baa7180-77f6-442d-9f70-778d11196eaf", false, "Client" },
                    { 3, 0, "bceb7e56-0e28-4a48-b609-758dfc5fc9ca", null, true, true, null, null, "COURIER", "AQAAAAEAACcQAAAAEKJhiIxsAFB7G3WQFvnQOaAiNJFKgAC5w651qV89Q8odev+9m2UssBLQ598C9mWiUw==", null, false, "72a9b940-f921-4c64-9171-47739404d241", false, "Courier" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d983ed4b-1563-49f9-952a-ef165f23fa6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "560fd452-b1ad-4310-bf4c-fad80f60b4a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7673b11d-f454-4f81-923a-cf825dd9d21e");
        }
    }
}
