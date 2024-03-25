using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentBio.Migrations
{
    /// <inheritdoc />
    public partial class Added_ExerciseId_To_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "AppStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppStudents_ExerciseId",
                table: "AppStudents",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudents_AppExercises_ExerciseId",
                table: "AppStudents",
                column: "ExerciseId",
                principalTable: "AppExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStudents_AppExercises_ExerciseId",
                table: "AppStudents");

            migrationBuilder.DropIndex(
                name: "IX_AppStudents_ExerciseId",
                table: "AppStudents");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "AppStudents");
        }
    }
}
