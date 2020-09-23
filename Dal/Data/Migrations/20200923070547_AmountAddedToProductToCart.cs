using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class AmountAddedToProductToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ProductToCartEntity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                column: "Name",
                value: "Second Cart");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProductToCartEntity");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: "1b760d44-10eb-4596-9d6f-da45e4e9a228",
                column: "Name",
                value: "First Cart");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "024974876");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "490271544");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "050612024");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "218825662");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "055686988");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                column: "EAN",
                value: "583775848");
        }
    }
}
