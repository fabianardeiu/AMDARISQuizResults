using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisQuizResultsApi.Migrations
{
    public partial class New_Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizToQuestions_Questions_Id",
                table: "QuizToQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizToQuestions_Quizzes_Id",
                table: "QuizToQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizToQuestions_Id",
                table: "QuizToQuestions");

            migrationBuilder.CreateIndex(
                name: "IX_QuizToQuestions_QuizId",
                table: "QuizToQuestions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizToQuestions_Questions_QuestionId",
                table: "QuizToQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizToQuestions_Quizzes_QuizId",
                table: "QuizToQuestions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizToQuestions_Questions_QuestionId",
                table: "QuizToQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizToQuestions_Quizzes_QuizId",
                table: "QuizToQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizToQuestions_QuizId",
                table: "QuizToQuestions");

            migrationBuilder.CreateIndex(
                name: "IX_QuizToQuestions_Id",
                table: "QuizToQuestions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizToQuestions_Questions_Id",
                table: "QuizToQuestions",
                column: "Id",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizToQuestions_Quizzes_Id",
                table: "QuizToQuestions",
                column: "Id",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
