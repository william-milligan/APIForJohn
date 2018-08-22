using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SurveyAppApi.Migrations
{
    public partial class UpdateToPagination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "Paginations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaginationString",
                table: "Paginations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageName",
                table: "Paginations");

            migrationBuilder.DropColumn(
                name: "PaginationString",
                table: "Paginations");
        }
    }
}
