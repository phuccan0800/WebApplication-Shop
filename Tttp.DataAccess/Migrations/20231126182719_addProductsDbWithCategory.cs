using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationTEST.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsDbWithCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_CategoryId",
                table: "ProductModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryId",
                table: "ProductModel",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_CategoryId",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductModel");
        }
    }
}
