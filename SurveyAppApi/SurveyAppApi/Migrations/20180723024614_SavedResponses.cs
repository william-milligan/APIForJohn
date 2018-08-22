using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SurveyAppApi.Migrations
{
    public partial class SavedResponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_PossibleAnswers_Questions_QuestionId",
                table: "PossibleAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Responces_CompletedSurveys_CompletedSurveyId",
                table: "Responces");

            migrationBuilder.DropForeignKey(
                name: "FK_Responces_Questions_QuestionId",
                table: "Responces");

            migrationBuilder.DropForeignKey(
                name: "FK_SubQuestions_Questions_QuestionId",
                table: "SubQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Responces",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Responces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InProgressResponses",
                columns: table => new
                {
                    InProgressResponsesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParticipantId = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false),
                    SurveyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InProgressResponses", x => x.InProgressResponsesId);
                });

            migrationBuilder.CreateTable(
                name: "InProgressResponse",
                columns: table => new
                {
                    InProgressResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    InprogressResponsesId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InProgressResponse", x => x.InProgressResponseId);
                    table.ForeignKey(
                        name: "FK_InProgressResponse_InProgressResponses_InprogressResponsesId",
                        column: x => x.InprogressResponsesId,
                        principalTable: "InProgressResponses",
                        principalColumn: "InProgressResponsesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InProgressResponse_InprogressResponsesId",
                table: "InProgressResponse",
                column: "InprogressResponsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedSurveys_Surveys_SurveyId",
                table: "CompletedSurveys",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PossibleAnswers_Questions_QuestionId",
                table: "PossibleAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responces_CompletedSurveys_CompletedSurveyId",
                table: "Responces",
                column: "CompletedSurveyId",
                principalTable: "CompletedSurveys",
                principalColumn: "CompletedSurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responces_Questions_QuestionId",
                table: "Responces",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubQuestions_Questions_QuestionId",
                table: "SubQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedSurveys_Surveys_SurveyId",
                table: "CompletedSurveys");

            migrationBuilder.DropForeignKey(
                name: "FK_PossibleAnswers_Questions_QuestionId",
                table: "PossibleAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Responces_CompletedSurveys_CompletedSurveyId",
                table: "Responces");

            migrationBuilder.DropForeignKey(
                name: "FK_Responces_Questions_QuestionId",
                table: "Responces");

            migrationBuilder.DropForeignKey(
                name: "FK_SubQuestions_Questions_QuestionId",
                table: "SubQuestions");

            migrationBuilder.DropTable(
                name: "InProgressResponse");

            migrationBuilder.DropTable(
                name: "InProgressResponses");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Responces");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Responces",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedSurveys_Surveys_SurveyId",
                table: "CompletedSurveys",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PossibleAnswers_Questions_QuestionId",
                table: "PossibleAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responces_CompletedSurveys_CompletedSurveyId",
                table: "Responces",
                column: "CompletedSurveyId",
                principalTable: "CompletedSurveys",
                principalColumn: "CompletedSurveyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responces_Questions_QuestionId",
                table: "Responces",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubQuestions_Questions_QuestionId",
                table: "SubQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
