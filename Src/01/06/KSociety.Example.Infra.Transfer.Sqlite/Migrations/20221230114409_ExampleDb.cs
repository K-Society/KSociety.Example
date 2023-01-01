using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KSociety.Example.Infra.Transfer.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class ExampleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorName", "Title" },
                values: new object[,]
                {
                    { new Guid("0d9ddd0d-eda7-4347-b954-e521da8f02a2"), "5", "5" },
                    { new Guid("701fc68d-4aef-4ef3-b074-05e1ad021b2c"), "4", "4" },
                    { new Guid("7d9a0b7d-dab2-4d69-bee8-a4a68a3e12ad"), "3", "3" },
                    { new Guid("85ee13a1-4584-458f-9ef1-5c0101e54264"), "1", "1" },
                    { new Guid("93a2dfbe-8bf0-48c4-8210-1991bc95070f"), "2", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Title_AuthorName",
                table: "Book",
                columns: new[] { "Title", "AuthorName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
