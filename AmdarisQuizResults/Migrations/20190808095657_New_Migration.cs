using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisQuizResultsApi.Migrations
{
    public partial class New_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizToQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    QuizId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizToQuestions", x => new { x.QuestionId, x.QuizId });
                    table.UniqueConstraint("AK_QuizToQuestions_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizToQuestions_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizToQuestions_Quizzes_Id",
                        column: x => x.Id,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizToQuestions");
        }
    }
}
