using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "BookCopies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ShoppingCartId",
                table: "Members",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_ShoppingCartId",
                table: "BookCopies",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_ShoppingCart_ShoppingCartId",
                table: "BookCopies",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ShoppingCart_ShoppingCartId",
                table: "Members",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_ShoppingCart_ShoppingCartId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_ShoppingCart_ShoppingCartId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Members_ShoppingCartId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_BookCopies_ShoppingCartId",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "BookCopies");
        }
    }
}
