using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PracticeEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WarmUp = table.Column<bool>(type: "INTEGER", nullable: false),
                    Scales = table.Column<bool>(type: "INTEGER", nullable: false),
                    Intonation = table.Column<bool>(type: "INTEGER", nullable: false),
                    TechnicalExercises = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinutesPracticed = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracticeEntries");
        }
    }
}
