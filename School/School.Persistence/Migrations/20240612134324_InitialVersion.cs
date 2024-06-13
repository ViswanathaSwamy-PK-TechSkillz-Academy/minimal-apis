using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Credits", "Description", "Duration", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("63e64ad7-50b4-484c-895f-85b88e2f4115"), "Admin", new DateTimeOffset(new DateTime(2024, 6, 12, 13, 43, 22, 775, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 0, 0, 0, 0)), 5, null, 5, "Admin", new DateTimeOffset(new DateTime(2024, 6, 12, 13, 43, 22, 775, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate API Development" },
                    { new Guid("bd37818f-c8bb-4f15-8f5b-67e7f310a898"), "Admin", new DateTimeOffset(new DateTime(2024, 6, 12, 13, 43, 22, 775, DateTimeKind.Unspecified).AddTicks(9045), new TimeSpan(0, 0, 0, 0, 0)), 3, null, 3, "Admin", new DateTimeOffset(new DateTime(2024, 6, 12, 13, 43, 22, 775, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 0, 0, 0, 0)), "Minimal API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
