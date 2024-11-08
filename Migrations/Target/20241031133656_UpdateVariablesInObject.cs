using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSync.Migrations.Target
{
    /// <inheritdoc />
    public partial class UpdateVariablesInObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_SingleChoiceOption_SingleChoiceOptionId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_ENSIAQuestionMetadata_QuestionId",
                table: "ENSIAQuestionMetadata");

            migrationBuilder.RenameColumn(
                name: "SingleChoiceOptionId",
                table: "Question",
                newName: "LinkedChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SingleChoiceOptionId",
                table: "Question",
                newName: "IX_Question_LinkedChoiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SystemType",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ENSIAQuestionMetadataId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENSIAQuestionMetadata_QuestionId",
                table: "ENSIAQuestionMetadata",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_SingleChoiceOption_LinkedChoiceId",
                table: "Question",
                column: "LinkedChoiceId",
                principalTable: "SingleChoiceOption",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_SingleChoiceOption_LinkedChoiceId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_ENSIAQuestionMetadata_QuestionId",
                table: "ENSIAQuestionMetadata");

            migrationBuilder.DropColumn(
                name: "ENSIAQuestionMetadataId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "LinkedChoiceId",
                table: "Question",
                newName: "SingleChoiceOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_LinkedChoiceId",
                table: "Question",
                newName: "IX_Question_SingleChoiceOptionId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SystemType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_ENSIAQuestionMetadata_QuestionId",
                table: "ENSIAQuestionMetadata",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_SingleChoiceOption_SingleChoiceOptionId",
                table: "Question",
                column: "SingleChoiceOptionId",
                principalTable: "SingleChoiceOption",
                principalColumn: "Id");
        }
    }
}
