using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EAN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductToCartEntity",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    CartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToCartEntity", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductToCartEntity_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToCartEntity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "First Cart", "a7b420a1-66cc-42b3-8bc0-5bc3abf39850" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "First Cart", "a7b420a1-66cc-42b3-8bc0-5bc3abf39850" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da12e4e9a228", "024974876", "Vr Glasses" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d45-10eb-4596-9d6f-da12e4e9a228", "490271544", "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d46-10eb-4596-9d6f-da12e4e9a228", "050612024", "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d47-10eb-4596-9d6f-da12e4e9a228", "218825662", "Ventilator" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d48-10eb-4596-9d6f-da12e4e9a228", "055686988", "Charger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name" },
                values: new object[] { "4b760d49-10eb-4596-9d6f-da12e4e9a228", "583775848", "Cup" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d44-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d45-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d46-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "4b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d47-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d48-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntity",
                columns: new[] { "CartId", "ProductId" },
                values: new object[] { "1b760d44-10eb-4596-9d6f-da45e4e9a228", "4b760d49-10eb-4596-9d6f-da12e4e9a228" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCartEntity_ProductId",
                table: "ProductToCartEntity",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductToCartEntity");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
