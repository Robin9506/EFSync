using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSync.Migrations
{
    /// <inheritdoc />
    public partial class NewVariablesForObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Archived",
                table: "QuestionListSection",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QuestionListSection",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "QuestionListSection",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "QuestionListSection",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QuestionListSection",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Archived",
                table: "QuestionList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QuestionList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "QuestionList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "QuestionList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QuestionList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Archived",
                table: "Question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Question",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Question",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "QuestionListSection");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QuestionListSection");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "QuestionListSection");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "QuestionListSection");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QuestionListSection");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "QuestionList");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QuestionList");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "QuestionList");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "QuestionList");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QuestionList");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Question");
        }
    }
}
