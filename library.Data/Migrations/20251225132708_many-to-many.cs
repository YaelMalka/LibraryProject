using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_borrows_CustomerId",
                table: "borrows",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_books_BorrowId",
                table: "books",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_books_CustomerId",
                table: "books",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_borrows_BorrowId",
                table: "books",
                column: "BorrowId",
                principalTable: "borrows",
                principalColumn: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrows_customers_CustomerId",
                table: "borrows",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_borrows_BorrowId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrows_customers_CustomerId",
                table: "borrows");

            migrationBuilder.DropIndex(
                name: "IX_borrows_CustomerId",
                table: "borrows");

            migrationBuilder.DropIndex(
                name: "IX_books_BorrowId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_CustomerId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "books");
        }
    }
}
