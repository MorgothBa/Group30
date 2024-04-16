using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moodle.Data.Migrations
{
    /// <inheritdoc />
    public partial class connected_datatables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree_Id",
                table: "User",
                newName: "DegreeId");

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCourse_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedDegree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedDegree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovedDegree_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovedDegree_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DegreeId",
                table: "User",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedDegree_CourseId",
                table: "ApprovedDegree",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedDegree_DegreeId",
                table: "ApprovedDegree",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CourseId",
                table: "Event",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_CourseId",
                table: "MyCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_UserId",
                table: "MyCourse",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Degree_DegreeId",
                table: "User",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Degree_DegreeId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ApprovedDegree");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "MyCourse");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropIndex(
                name: "IX_User_DegreeId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "User",
                newName: "Degree_Id");
        }
    }
}
