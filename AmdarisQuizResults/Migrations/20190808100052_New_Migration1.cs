using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisQuizResultsApi.Migrations
{
    public partial class New_Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_QuizToQuestions_Id",
                table: "QuizToQuestions");

            migrationBuilder.CreateIndex(
                name: "IX_QuizToQuestions_Id",
                table: "QuizToQuestions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizToQuestions_Id",
                table: "QuizToQuestions");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_QuizToQuestions_Id",
                table: "QuizToQuestions",
                column: "Id");
        }
    }
}
