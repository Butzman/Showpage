using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
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
                    EAN = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductToCartEntities",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    CartId = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToCartEntities", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductToCartEntities_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { "c1", "First Cart", "a7b420a1-66cc-42b3-8bc0-5bc3abf39850" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { "c2", "Second Cart", "a7b420a1-66cc-42b3-8bc0-5bc3abf39850" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p1", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "859577669", "Vr Glasses" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p2", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "123431087", "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p3", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "010624117", "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p4", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "126908458", "Ventilator" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p5", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "839435384", "Charger" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EAN", "Name" },
                values: new object[] { "p6", "This is a Descriptions. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.", "262768465", "Cup" });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p1", 2 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p2", 2 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p3", 4 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p4", 2 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p5", 4 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c1", "p6", 5 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c2", "p1", 6 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c2", "p2", 1 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c2", "p3", 4 });

            migrationBuilder.InsertData(
                table: "ProductToCartEntities",
                columns: new[] { "CartId", "ProductId", "Amount" },
                values: new object[] { "c2", "p4", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductToCartEntities");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
