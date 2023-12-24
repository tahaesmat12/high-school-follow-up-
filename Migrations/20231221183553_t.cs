using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addingmodel_1",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "int", nullable: false),
                    studentname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    behaviour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    teachername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coursename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseid);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    gradeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.gradeid);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    parentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parentimage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.parentid);
                    table.CheckConstraint("CK_ParentName_LettersAndSpaces", "[ParentName] LIKE '%[a-zA-Z ]%'");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    behaviour = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentid);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacherid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teachername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacherid);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseGrades",
                columns: table => new
                {
                    studentcoursegradeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    gradeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseGrades", x => x.studentcoursegradeid);
                    table.ForeignKey(
                        name: "FK_StudentCourseGrades_Courses_courseid",
                        column: x => x.courseid,
                        principalTable: "Courses",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseGrades_Grades_gradeid",
                        column: x => x.gradeid,
                        principalTable: "Grades",
                        principalColumn: "gradeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseGrades_Students_studentid",
                        column: x => x.studentid,
                        principalTable: "Students",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Cascade);
                
                });

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    studentparentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    parentid = table.Column<int>(type: "int", nullable: false),
                    parentid1 = table.Column<int>(type: "int", nullable: true),
                    studentid1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => x.studentparentid);
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_parentid",
                        column: x => x.parentid,
                        principalTable: "Parents",
                        principalColumn: "parentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_parentid1",
                        column: x => x.parentid1,
                        principalTable: "Parents",
                        principalColumn: "parentid");
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_studentid",
                        column: x => x.studentid,
                        principalTable: "Students",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_studentid1",
                        column: x => x.studentid1,
                        principalTable: "Students",
                        principalColumn: "studentid");
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    teachercourseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherid = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    courseid1 = table.Column<int>(type: "int", nullable: true),
                    teacherid1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.teachercourseid);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_courseid",
                        column: x => x.courseid,
                        principalTable: "Courses",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_courseid1",
                        column: x => x.courseid1,
                        principalTable: "Courses",
                        principalColumn: "courseid");
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_teacherid",
                        column: x => x.teacherid,
                        principalTable: "Teachers",
                        principalColumn: "teacherid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_teacherid1",
                        column: x => x.teacherid1,
                        principalTable: "Teachers",
                        principalColumn: "teacherid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseGrades_courseid",
                table: "StudentCourseGrades",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseGrades_gradeid",
                table: "StudentCourseGrades",
                column: "gradeid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseGrades_studentid",
                table: "StudentCourseGrades",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_parentid",
                table: "StudentParents",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_parentid1",
                table: "StudentParents",
                column: "parentid1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_studentid",
                table: "StudentParents",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_studentid1",
                table: "StudentParents",
                column: "studentid1");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_courseid",
                table: "TeacherCourses",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_courseid1",
                table: "TeacherCourses",
                column: "courseid1");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherid",
                table: "TeacherCourses",
                column: "teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_teacherid1",
                table: "TeacherCourses",
                column: "teacherid1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addingmodel_1");

            migrationBuilder.DropTable(
                name: "StudentCourseGrades");

            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
