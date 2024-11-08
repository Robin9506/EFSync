using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSync.Migrations.Target
{
    /// <inheritdoc />
    public partial class AddedSingleAndMultpleChoiceOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SingleChoiceOptionId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ENSIAQuestionMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ENSIACode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENSIAId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalMeasure = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archived = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENSIAQuestionMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENSIAQuestionMetadata_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    CanHaveRemarkAnswer = table.Column<bool>(type: "bit", nullable: false),
                    CanHaveLink = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compliant = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archived = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleChoiceOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    CanHaveRemarkAnswer = table.Column<bool>(type: "bit", nullable: false),
                    CanHaveLink = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanGenerateTask = table.Column<bool>(type: "bit", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compliant = table.Column<bool>(type: "bit", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archived = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleChoiceOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleChoiceOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_SingleChoiceOptionId",
                table: "Question",
                column: "SingleChoiceOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ENSIAQuestionMetadata_QuestionId",
                table: "ENSIAQuestionMetadata",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceOption_QuestionId",
                table: "MultipleChoiceOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleChoiceOption_QuestionId",
                table: "SingleChoiceOption",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_SingleChoiceOption_SingleChoiceOptionId",
                table: "Question",
                column: "SingleChoiceOptionId",
                principalTable: "SingleChoiceOption",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_SingleChoiceOption_SingleChoiceOptionId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "ENSIAQuestionMetadata");

            migrationBuilder.DropTable(
                name: "MultipleChoiceOption");

            migrationBuilder.DropTable(
                name: "SingleChoiceOption");

            migrationBuilder.DropIndex(
                name: "IX_Question_SingleChoiceOptionId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SingleChoiceOptionId",
                table: "Question");
        }
    }
}
