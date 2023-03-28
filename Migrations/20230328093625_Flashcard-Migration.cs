using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashcardLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FlashcardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Flashcards_Categories_CategoryObjectID",
                        column: x => x.CategoryObjectID,
                        principalTable: "Categories",
                        principalColumn: "ObjectID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CategoryObjectID",
                table: "Flashcards",
                column: "CategoryObjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
