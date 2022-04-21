using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.App.Infrastructure.Migrations
{
    public partial class AddCategoryToScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Scores",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CategoryId",
                table: "Scores",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Categories_CategoryId",
                table: "Scores",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Categories_CategoryId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CategoryId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Scores");
        }
    }
}
