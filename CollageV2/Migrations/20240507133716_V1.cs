using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollageV2.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    A_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AD_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.A_Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrsDuration = table.Column<int>(type: "int", nullable: true),
                    Ex_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Crs_Id);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    Q_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.Q_Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.S_Id);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    Ex_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discruption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: true),
                    NumOfQs = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Crs_Id = table.Column<int>(type: "int", nullable: true),
                    Crs_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.Ex_Id);
                    table.ForeignKey(
                        name: "FK_exams_courses_Crs_Id1",
                        column: x => x.Crs_Id1,
                        principalTable: "courses",
                        principalColumn: "Crs_Id");
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    Op_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Q_Id = table.Column<int>(type: "int", nullable: false),
                    OpText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QIdNavigationQ_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.Op_Id);
                    table.ForeignKey(
                        name: "FK_options_question_QIdNavigationQ_Id",
                        column: x => x.QIdNavigationQ_Id,
                        principalTable: "question",
                        principalColumn: "Q_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    Result_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ex_Id = table.Column<int>(type: "int", nullable: false),
                    S_Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Ex_Id1 = table.Column<int>(type: "int", nullable: false),
                    StS_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.Result_Id);
                    table.ForeignKey(
                        name: "FK_results_exams_Ex_Id1",
                        column: x => x.Ex_Id1,
                        principalTable: "exams",
                        principalColumn: "Ex_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_results_students_StS_Id",
                        column: x => x.StS_Id,
                        principalTable: "students",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exams_Crs_Id1",
                table: "exams",
                column: "Crs_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_options_QIdNavigationQ_Id",
                table: "options",
                column: "QIdNavigationQ_Id");

            migrationBuilder.CreateIndex(
                name: "IX_results_Ex_Id1",
                table: "results",
                column: "Ex_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_results_StS_Id",
                table: "results",
                column: "StS_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
