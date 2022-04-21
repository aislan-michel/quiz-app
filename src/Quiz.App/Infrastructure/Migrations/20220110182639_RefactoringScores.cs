using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.App.Infrastructure.Migrations
{
    public partial class RefactoringScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Scores",
                newName: "QuestionsCount");

            migrationBuilder.RenameColumn(
                name: "Passed",
                table: "Scores",
                newName: "Approved");

            migrationBuilder.AddColumn<int>(
                name: "CorrectQuestionsCount",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncorrectQuestionsCount",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectQuestionsCount",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "IncorrectQuestionsCount",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "QuestionsCount",
                table: "Scores",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Scores",
                newName: "Passed");
        }
    }
}
