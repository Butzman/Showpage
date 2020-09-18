using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class AddsCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6879006f-d30b-443e-8459-032787b5cba7");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6eebb273-f690-4d76-800a-11b7560cf421");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "851de224-cd49-45d2-b183-affc3f3d5ebe");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b70b9b1d-a078-4c01-9981-7acdbec14d42");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "cc2c7445-633d-4e65-a4ca-5a0e2a231959");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "dd3d5795-7120-4d4d-91d6-2c982072d9ca");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da12e4e9a228", "099603759", "Vr Glasses" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d45-10eb-4596-9d6f-da12e4e9a228", "417303535", "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d46-10eb-4596-9d6f-da12e4e9a228", "428294030", "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d47-10eb-4596-9d6f-da12e4e9a228", "544671531", "Ventilator" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d48-10eb-4596-9d6f-da12e4e9a228", "580552543", "Charger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d49-10eb-4596-9d6f-da12e4e9a228", "077770322", "Cup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d44-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d45-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d46-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d47-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d48-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4b760d49-10eb-4596-9d6f-da12e4e9a228");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "b70b9b1d-a078-4c01-9981-7acdbec14d42", "319309849", "Vr Glasses" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "6eebb273-f690-4d76-800a-11b7560cf421", "641488645", "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "dd3d5795-7120-4d4d-91d6-2c982072d9ca", "392637592", "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "6879006f-d30b-443e-8459-032787b5cba7", "259038295", "Ventilator" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "851de224-cd49-45d2-b183-affc3f3d5ebe", "748736059", "Charger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "cc2c7445-633d-4e65-a4ca-5a0e2a231959", "385235601", "Cup" });
        }
    }
}
