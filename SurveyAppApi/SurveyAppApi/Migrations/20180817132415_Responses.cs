using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SurveyAppApi.Migrations
{
    public partial class Responses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompletedSurveys");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPage",
                table: "InProgressResponse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParticipantId",
                table: "CompletedSurveys",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    CompletedSurveyId = table.Column<int>(nullable: false),
                    QuestionAsked = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_CompletedSurveys_CompletedSurveyId",
                        column: x => x.CompletedSurveyId,
                        principalTable: "CompletedSurveys",
                        principalColumn: "CompletedSurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CompletedSurveyId",
                table: "Responses",
                column: "CompletedSurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropColumn(
                name: "CurrentPage",
                table: "InProgressResponse");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "CompletedSurveys");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CompletedSurveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Responces",
                columns: table => new
                {
                    ResponceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    CompletedSurveyId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true),
                    QuestionNumber = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responces", x => x.ResponceId);
                    table.ForeignKey(
                        name: "FK_Responces_CompletedSurveys_CompletedSurveyId",
                        column: x => x.CompletedSurveyId,
                        principalTable: "CompletedSurveys",
                        principalColumn: "CompletedSurveyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responces_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responces_CompletedSurveyId",
                table: "Responces",
                column: "CompletedSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responces_QuestionId",
                table: "Responces",
                column: "QuestionId");
        }
    }
}
