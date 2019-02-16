using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Initialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    TimeToPrep = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "DateCreated", "IsDeleted", "Name" },
                values: new object[] { 1, new DateTime(2019, 2, 16, 17, 14, 30, 948, DateTimeKind.Local).AddTicks(7651), false, "Lunch Menu" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "IsDeleted", "MenuId", "Name", "Price", "TimeToPrep" },
                values: new object[,]
                {
                    { 1, "It has everything you ever wanted in a sandwich. enough said", false, 1, "Nom your face off Sandwich", 100.0, 20 },
                    { 2, "Disappointed", false, 1, "I'm a vegan", 200.0, 60 },
                    { 3, "200g beef patty mixed with 10% sirloin, 10% rump and 80% more beef", false, 1, "Anti vegan burger", 120.0, 30 },
                    { 4, "Yes people pineapple on pizza, #dealwithit", false, 1, "Hawaiian pizza", 50.0, 25 },
                    { 5, "Good luck finding the feta or olives", false, 1, "Greek salad", 80.0, 5 },
                    { 6, "Because you never know what you gonna get", false, 1, "Uber eats special", 100.0, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuId",
                table: "Items",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
