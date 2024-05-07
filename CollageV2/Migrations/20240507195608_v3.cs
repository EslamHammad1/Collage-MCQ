using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollageV2.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exams_courses_Crs_Id1",
                table: "exams");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropIndex(
                name: "IX_exams_Crs_Id1",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Crs_Id",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "Crs_Id1",
                table: "exams");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "exams",
                newName: "TypeExam");

            migrationBuilder.RenameColumn(
                name: "Discruption",
                table: "exams",
                newName: "Duration");

            migrationBuilder.AddColumn<float>(
                name: "St_IDCode",
                table: "students",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentQS",
                table: "exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "exams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Ad_IDCode",
                table: "admins",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "St_IDCode",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "CurrentQS",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "Ad_IDCode",
                table: "admins");

            migrationBuilder.RenameColumn(
                name: "TypeExam",
                table: "exams",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "exams",
                newName: "Discruption");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Crs_Id",
                table: "exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Crs_Id1",
                table: "exams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrsDuration = table.Column<int>(type: "int", nullable: true),
                    CrsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ex_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Crs_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exams_Crs_Id1",
                table: "exams",
                column: "Crs_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_exams_courses_Crs_Id1",
                table: "exams",
                column: "Crs_Id1",
                principalTable: "courses",
                principalColumn: "Crs_Id");
        }
    }
}
