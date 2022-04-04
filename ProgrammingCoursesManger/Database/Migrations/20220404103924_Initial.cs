using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingCoursesManger.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawy języka C#", "Kurs C# I" },
                    { 2, "Skomplikowane strukury języka C# oraz praktyczne przykłady zastosowania", "Kurs C# II" },
                    { 3, "Podstawy języka węży", "Kurs Python I" },
                    { 4, "Jak otworzyć chodowlę węży", "Kurs Python II" },
                    { 5, "Nauka projektowania stron internetowych od podstaw", "Kurs HTML/JS" },
                    { 6, "Omówienie projektowania stron internetowych zarówno statycznych jak i SPA na przykładach w najpopularniejszych frameworkach JavaScript/TypeScript", "Kurs HTML/JS/TS" },
                    { 7, "Wprowadzenie do frameworka Angular zarówno dla początkujących jak i zaawansowanych", "Kurs Angular" },
                    { 8, "Wprowadzenie do frameworka React zarówno dla początkujących jak i zaawansowanych", "Kurs React" },
                    { 9, "Wprowadzenie do frameworka Vue zarówno dla początkujących jak i zaawansowanych", "Kurs Vue" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CourseId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 1, "C# I - Temat 1", 1 },
                    { 2, 1, "C# I - Temat 2", 2 },
                    { 3, 1, "C# I - Temat 3", 3 },
                    { 4, 2, "C# II - Temat 1", 1 },
                    { 5, 2, "C# II - Temat 2", 2 },
                    { 6, 2, "C# II - Temat 3", 3 },
                    { 7, 3, "Python I - Temat 1", 1 },
                    { 8, 3, "Python I - Temat 2", 2 },
                    { 9, 3, "Python I - Temat 3", 3 },
                    { 10, 3, "Python I - Temat 4", 4 },
                    { 11, 3, "Python I - Temat 5", 5 },
                    { 12, 4, "Python II - Temat 1", 1 },
                    { 13, 4, "Python II - Temat 2", 2 },
                    { 14, 5, "HTML", 1 },
                    { 15, 5, "JavaScript", 2 },
                    { 16, 6, "HTML", 1 },
                    { 17, 6, "JavaScript - Temat 1", 2 },
                    { 18, 6, "JavaScript - Temat 2", 3 },
                    { 19, 6, "JavaScript - Temat 3", 4 },
                    { 20, 6, "JavaScript - Temat 4", 5 },
                    { 21, 6, "TypeScript - Temat 1", 6 },
                    { 22, 6, "TypeScript - Temat 2", 7 },
                    { 23, 6, "Angular", 8 },
                    { 24, 6, "React", 9 },
                    { 25, 6, "Vue", 10 },
                    { 26, 7, "JavaScript", 1 },
                    { 27, 7, "Angular - Temat 1", 2 },
                    { 28, 7, "Angular - Temat 2", 3 },
                    { 29, 7, "Angular - Temat 3", 4 },
                    { 30, 7, "Angular - Temat 4", 5 },
                    { 31, 8, "JavaScript", 1 },
                    { 32, 8, "React - Temat 1", 2 },
                    { 33, 8, "React - Temat 2", 3 },
                    { 34, 8, "React - Temat 3", 4 },
                    { 35, 9, "JavaScript", 1 },
                    { 36, 9, "Vue - Temat 1", 2 },
                    { 37, 9, "Vue - Temat 2", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CourseId",
                table: "Topics",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
