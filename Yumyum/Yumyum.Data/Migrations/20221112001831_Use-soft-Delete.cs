using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yumyum.Data.Migrations
{
    public partial class UsesoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUserTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUserLogins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUserClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetRoleClaims",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetRoleClaims");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
