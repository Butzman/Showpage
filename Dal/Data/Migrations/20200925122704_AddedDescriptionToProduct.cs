using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class AddedDescriptionToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "264080034");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "077676738");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "761201977");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "920752782");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "717663653");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "308691606");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "601650479");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "135203584");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "227041624");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "303260305");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "414535918");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "457345923");
        }
    }
}
