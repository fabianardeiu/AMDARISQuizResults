using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisQuizResultsApi.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "QuizResults");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "QuizResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "QuizResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_ParticipantId",
                table: "QuizResults",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Participants_ParticipantId",
                table: "QuizResults",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Participants_ParticipantId",
                table: "QuizResults");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_ParticipantId",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuizResults");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "QuizResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "QuizResults",
                nullable: true);
        }
    }
}
