using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_resell_app.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertiesForProduct8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CityId",
                table: "Products",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
