using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84dcadf1-a0e0-42b4-98cf-288048fd791c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1240a7f-0f4e-43fe-b789-2980da536a22");

            migrationBuilder.AddColumn<int>(
                name: "AvgRating",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1133cc8c-f285-4aba-83ac-02c909daaaaa", "e62e7888-3fa9-476a-bb1c-f0694277a100", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "132dd54d-a9cb-4191-a765-f6f07d821f3b", "75513337-e25d-4c36-b634-6fbe5ea87929", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1133cc8c-f285-4aba-83ac-02c909daaaaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "132dd54d-a9cb-4191-a765-f6f07d821f3b");

            migrationBuilder.DropColumn(
                name: "AvgRating",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1240a7f-0f4e-43fe-b789-2980da536a22", "91b79972-5b3b-4570-bcac-483954b4ab7f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84dcadf1-a0e0-42b4-98cf-288048fd791c", "3ab4142e-3ee1-436c-a98c-1d8e06c2f62c", "User", null });
        }
    }
}
