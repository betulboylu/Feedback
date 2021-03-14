using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackMicroservice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[] { 1, new DateTime(2021, 3, 13, 16, 9, 43, 236, DateTimeKind.Local).AddTicks(363), false, "For Honor" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CreatedDate", "GameId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 13, 16, 9, 43, 238, DateTimeKind.Local).AddTicks(8422), 1, false },
                    { 2, new DateTime(2021, 3, 13, 16, 9, 43, 238, DateTimeKind.Local).AddTicks(9020), 1, false },
                    { 3, new DateTime(2021, 3, 13, 16, 9, 43, 238, DateTimeKind.Local).AddTicks(9027), 1, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 13, 16, 9, 43, 238, DateTimeKind.Local).AddTicks(9872), true, false, "User1" },
                    { 2, new DateTime(2021, 3, 13, 16, 9, 43, 239, DateTimeKind.Local).AddTicks(471), true, false, "User2" },
                    { 3, new DateTime(2021, 3, 13, 16, 9, 43, 239, DateTimeKind.Local).AddTicks(477), true, false, "User3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
