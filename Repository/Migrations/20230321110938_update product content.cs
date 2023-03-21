using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateproductcontent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductContent",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContent_Products_ProductId",
                table: "ProductContent",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductContent_Products_ProductId",
                table: "ProductContent");

            migrationBuilder.DropIndex(
                name: "IX_ProductContent_ProductId",
                table: "ProductContent");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductContent");
        }
    }
}
