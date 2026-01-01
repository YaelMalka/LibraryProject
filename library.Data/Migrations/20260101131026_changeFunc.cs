using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class changeFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_borrows_BorrowId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_BorrowId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_BorrowId",
                table: "books",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_borrows_BorrowId",
                table: "books",
                column: "BorrowId",
                principalTable: "borrows",
                principalColumn: "BorrowId");
        }
    }
}
