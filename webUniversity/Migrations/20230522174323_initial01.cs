using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webUniversity.Migrations
{
    /// <inheritdoc />
    public partial class initial01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlForms",
                columns: table => new
                {
                    controlFormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlForms", x => x.controlFormID);
                });

            migrationBuilder.CreateTable(
                name: "ControlPeriods",
                columns: table => new
                {
                    controlPeriodID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPeriods", x => x.controlPeriodID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    disciplineID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true),
                    fullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.disciplineID);
                });

            migrationBuilder.CreateTable(
                name: "Facultys",
                columns: table => new
                {
                    facultyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultys", x => x.facultyID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    groupID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.groupID);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    markID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.markID);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    orderTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.orderTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    professorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.professorID);
                });

            migrationBuilder.CreateTable(
                name: "Specialitys",
                columns: table => new
                {
                    specialityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true),
                    specialityCode = table.Column<string>(type: "text", nullable: true),
                    largeGroup = table.Column<string>(type: "text", nullable: true),
                    branchScience = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialitys", x => x.specialityID);
                });

            migrationBuilder.CreateTable(
                name: "StatementTypes",
                columns: table => new
                {
                    statementTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementTypes", x => x.statementTypeID);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatuss",
                columns: table => new
                {
                    studentStatusTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatuss", x => x.studentStatusTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingLevels",
                columns: table => new
                {
                    trainingLevelID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingLevels", x => x.trainingLevelID);
                });

            migrationBuilder.CreateTable(
                name: "TuitionForms",
                columns: table => new
                {
                    tuitionFormlID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionForms", x => x.tuitionFormlID);
                });

            migrationBuilder.CreateTable(
                name: "TuitionTypes",
                columns: table => new
                {
                    tuitionTypelID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionTypes", x => x.tuitionTypelID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    authID = table.Column<int>(type: "integer", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    specializationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    addName = table.Column<string>(type: "text", nullable: true),
                    specializationCode = table.Column<string>(type: "text", nullable: true),
                    specialityID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.specializationID);
                    table.ForeignKey(
                        name: "FK_Specializations_Specialitys_specialityID",
                        column: x => x.specialityID,
                        principalTable: "Specialitys",
                        principalColumn: "specialityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    gradebook = table.Column<string>(type: "text", nullable: true),
                    lastName = table.Column<string>(type: "text", nullable: true),
                    firstName = table.Column<string>(type: "text", nullable: true),
                    patronomic = table.Column<string>(type: "text", nullable: true),
                    groupID = table.Column<int>(type: "integer", nullable: false),
                    tuitionTypeID = table.Column<int>(type: "integer", nullable: false),
                    tuitionFormID = table.Column<int>(type: "integer", nullable: false),
                    trainingLevelID = table.Column<int>(type: "integer", nullable: false),
                    studentStatusID = table.Column<int>(type: "integer", nullable: false),
                    specialityID = table.Column<int>(type: "integer", nullable: false),
                    specializationID = table.Column<int>(type: "integer", nullable: false),
                    courseID = table.Column<int>(type: "integer", nullable: false),
                    userID = table.Column<int>(type: "integer", nullable: false),
                    facultyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_Students_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Facultys_facultyID",
                        column: x => x.facultyID,
                        principalTable: "Facultys",
                        principalColumn: "facultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Groups_groupID",
                        column: x => x.groupID,
                        principalTable: "Groups",
                        principalColumn: "groupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Specialitys_specialityID",
                        column: x => x.specialityID,
                        principalTable: "Specialitys",
                        principalColumn: "specialityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Specializations_specializationID",
                        column: x => x.specializationID,
                        principalTable: "Specializations",
                        principalColumn: "specializationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_StudentStatuss_studentStatusID",
                        column: x => x.studentStatusID,
                        principalTable: "StudentStatuss",
                        principalColumn: "studentStatusTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_TrainingLevels_trainingLevelID",
                        column: x => x.trainingLevelID,
                        principalTable: "TrainingLevels",
                        principalColumn: "trainingLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_TuitionForms_tuitionFormID",
                        column: x => x.tuitionFormID,
                        principalTable: "TuitionForms",
                        principalColumn: "tuitionFormlID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_TuitionTypes_tuitionTypeID",
                        column: x => x.tuitionTypeID,
                        principalTable: "TuitionTypes",
                        principalColumn: "tuitionTypelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ordersID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    isImplemented = table.Column<bool>(type: "boolean", nullable: true),
                    number = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    data = table.Column<int>(type: "integer", nullable: true),
                    dataStart = table.Column<int>(type: "integer", nullable: true),
                    dataEnd = table.Column<int>(type: "integer", nullable: true),
                    studentID = table.Column<int>(type: "integer", nullable: false),
                    orderTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ordersID);
                    table.ForeignKey(
                        name: "FK_Orders_OrderType_orderTypeID",
                        column: x => x.orderTypeID,
                        principalTable: "OrderType",
                        principalColumn: "orderTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    statementID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<int>(type: "integer", nullable: true),
                    timeStart = table.Column<int>(type: "integer", nullable: true),
                    timeEnd = table.Column<int>(type: "integer", nullable: true),
                    isIndividual = table.Column<bool>(type: "boolean", nullable: true),
                    statementTypeID = table.Column<int>(type: "integer", nullable: false),
                    controlFormID = table.Column<int>(type: "integer", nullable: false),
                    disciplineID = table.Column<int>(type: "integer", nullable: false),
                    controlPeriodID = table.Column<int>(type: "integer", nullable: false),
                    markID = table.Column<int>(type: "integer", nullable: false),
                    professorID = table.Column<int>(type: "integer", nullable: false),
                    studentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.statementID);
                    table.ForeignKey(
                        name: "FK_Statements_ControlForms_controlFormID",
                        column: x => x.controlFormID,
                        principalTable: "ControlForms",
                        principalColumn: "controlFormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_ControlPeriods_controlPeriodID",
                        column: x => x.controlPeriodID,
                        principalTable: "ControlPeriods",
                        principalColumn: "controlPeriodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_Disciplines_disciplineID",
                        column: x => x.disciplineID,
                        principalTable: "Disciplines",
                        principalColumn: "disciplineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_Marks_markID",
                        column: x => x.markID,
                        principalTable: "Marks",
                        principalColumn: "markID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_Professors_professorID",
                        column: x => x.professorID,
                        principalTable: "Professors",
                        principalColumn: "professorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_StatementTypes_statementTypeID",
                        column: x => x.statementTypeID,
                        principalTable: "StatementTypes",
                        principalColumn: "statementTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderTypeID",
                table: "Orders",
                column: "orderTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_studentID",
                table: "Orders",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_specialityID",
                table: "Specializations",
                column: "specialityID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_controlFormID",
                table: "Statements",
                column: "controlFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_controlPeriodID",
                table: "Statements",
                column: "controlPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_disciplineID",
                table: "Statements",
                column: "disciplineID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_markID",
                table: "Statements",
                column: "markID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_professorID",
                table: "Statements",
                column: "professorID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_statementTypeID",
                table: "Statements",
                column: "statementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_studentID",
                table: "Statements",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_courseID",
                table: "Students",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_facultyID",
                table: "Students",
                column: "facultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_groupID",
                table: "Students",
                column: "groupID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_specialityID",
                table: "Students",
                column: "specialityID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_specializationID",
                table: "Students",
                column: "specializationID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_studentStatusID",
                table: "Students",
                column: "studentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_trainingLevelID",
                table: "Students",
                column: "trainingLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_tuitionFormID",
                table: "Students",
                column: "tuitionFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_tuitionTypeID",
                table: "Students",
                column: "tuitionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_userID",
                table: "Students",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "ControlForms");

            migrationBuilder.DropTable(
                name: "ControlPeriods");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "StatementTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Facultys");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "StudentStatuss");

            migrationBuilder.DropTable(
                name: "TrainingLevels");

            migrationBuilder.DropTable(
                name: "TuitionForms");

            migrationBuilder.DropTable(
                name: "TuitionTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specialitys");
        }
    }
}
