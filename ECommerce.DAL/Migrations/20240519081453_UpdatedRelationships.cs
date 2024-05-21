using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "cartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "cartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "cartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id");
        }
    }
}
