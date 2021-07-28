using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class pv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134f4034-4973-467c-adce-5c8dc71c210d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d7b6b0-4a8b-4f9a-92ee-4f2693f606a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1240a7f-0f4e-43fe-b789-2980da536a22", "91b79972-5b3b-4570-bcac-483954b4ab7f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84dcadf1-a0e0-42b4-98cf-288048fd791c", "3ab4142e-3ee1-436c-a98c-1d8e06c2f62c", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84dcadf1-a0e0-42b4-98cf-288048fd791c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1240a7f-0f4e-43fe-b789-2980da536a22");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7d7b6b0-4a8b-4f9a-92ee-4f2693f606a5", "a66a532e-4515-43b0-879d-e35730afedce", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "134f4034-4973-467c-adce-5c8dc71c210d", "c5049883-edd7-40a3-ae13-43c1668c141b", "User", null });
        }
    }
}
