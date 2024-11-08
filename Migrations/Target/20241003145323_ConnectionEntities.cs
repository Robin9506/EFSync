using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSync.Migrations.Target
{
    /// <inheritdoc />
    public partial class ConnectionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionListSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionListSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionListSection_QuestionList_QuestionListId",
                        column: x => x.QuestionListId,
                        principalTable: "QuestionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionListSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QuestionListSection_QuestionListSectionId",
                        column: x => x.QuestionListSectionId,
                        principalTable: "QuestionListSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionListSectionId",
                table: "Question",
                column: "QuestionListSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionListSection_QuestionListId",
                table: "QuestionListSection",
                column: "QuestionListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionListSection");
        }
    }
}
