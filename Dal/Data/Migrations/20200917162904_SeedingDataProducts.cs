using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class SeedingDataProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "3d005a35-a852-4a16-a4da-bea5d9886734", "305190653", "Vr Glasses" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "dcf83ad5-1d99-4568-9b56-c5aac9673131", "305716906", "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "02573f26-1472-42dc-9a5e-9692cedc988f", "975588959", "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "b81f326c-4288-4f8d-a102-8a1fa31187e1", "742652122", "Ventilator" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "3bafc2d1-8179-476a-b1ab-1e18abf945fb", "019358550", "Charger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "e90b854a-2bcd-4152-8e96-766c240c6126", "668631386", "Cup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "02573f26-1472-42dc-9a5e-9692cedc988f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3bafc2d1-8179-476a-b1ab-1e18abf945fb");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3d005a35-a852-4a16-a4da-bea5d9886734");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b81f326c-4288-4f8d-a102-8a1fa31187e1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "dcf83ad5-1d99-4568-9b56-c5aac9673131");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "e90b854a-2bcd-4152-8e96-766c240c6126");
        }
    }
}
