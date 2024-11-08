using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFSync.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemTypeId = table.Column<int>(type: "int", nullable: false),
                    SystemPhase = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionList_SystemType_SystemTypeId",
                        column: x => x.SystemTypeId,
                        principalTable: "SystemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionList_SystemTypeId",
                table: "QuestionList",
                column: "SystemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionList");

            migrationBuilder.DropTable(
                name: "SystemType");
        }
    }
}
