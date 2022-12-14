using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yumyum.Data.Migrations
{
    public partial class updatemealrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MealRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MealRatings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MealRatings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MealRatings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MealRatings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MealRatings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MealRatings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MealRatings");
        }
    }
}
