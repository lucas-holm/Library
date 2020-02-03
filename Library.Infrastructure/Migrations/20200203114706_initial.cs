using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDetails_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<int>(nullable: false),
                    DetailsId = table.Column<int>(nullable: false),
                    LoanStart = table.Column<DateTime>(nullable: true),
                    BookStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_BookDetails_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "BookDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCopyId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    LoanStart = table.Column<DateTime>(nullable: false),
                    LoanEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "William Shakespeare" },
                    { 2, "Villiam Skakspjut" },
                    { 3, "Robert C. Martin" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Name", "SSN" },
                values: new object[,]
                {
                    { 1, "Kjell Svantesson", "1234567890" },
                    { 2, "Maja Svantesson", "1122334455" },
                    { 3, "Ola Svantesson", "5544332211" }
                });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[] { 1, 1, "Arguably Shakespeare's greatest tragedy", "1472518381", "Hamlet" });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[] { 2, 2, "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.", "9780141012292", "King Lear" });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[] { 3, 3, "An intense drama of love, deception, jealousy and destruction.", "1853260185", "Othello" });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "BookStatus", "Condition", "DetailsId", "LoanStart" },
                values: new object[] { 1, 0, 0, 1, null });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "BookStatus", "Condition", "DetailsId", "LoanStart" },
                values: new object[] { 2, 0, 2, 2, null });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "BookStatus", "Condition", "DetailsId", "LoanStart" },
                values: new object[] { 3, 0, 1, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_DetailsId",
                table: "BookCopies",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_AuthorId",
                table: "BookDetails",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyId",
                table: "Loans",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
