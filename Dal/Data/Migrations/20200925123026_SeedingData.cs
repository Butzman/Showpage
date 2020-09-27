using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d48-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d49-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "544388910" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "195654221" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "094139697" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "926004429" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "698472040" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "391356246" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d48-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d49-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductToCartEntity",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" },
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "264080034" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "077676738" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "761201977" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "920752782" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "717663653" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228",
                columns: new[] { "Description", "EAN" },
                values: new object[] { null, "308691606" });
        }
    }
}
