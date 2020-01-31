using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class UpdatedBookCopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_BookDetails_DetailsId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanStart",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoanEnd",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BookDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DetailsId",
                table: "BookCopies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "BookCopies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanStart",
                table: "BookCopies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Condition",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Condition",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_BookDetails_DetailsId",
                table: "BookCopies",
                column: "DetailsId",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_BookDetails_DetailsId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "LoanStart",
                table: "BookCopies");

            migrationBuilder.AlterColumn<string>(
                name: "LoanStart",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "LoanEnd",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BookDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DetailsId",
                table: "BookCopies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_BookDetails_DetailsId",
                table: "BookCopies",
                column: "DetailsId",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
