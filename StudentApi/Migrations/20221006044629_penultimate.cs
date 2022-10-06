using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApi.Migrations
{
    public partial class penultimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedDate",
                table: "student_table",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordCreationDate",
                table: "student_table",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditedDate",
                table: "student_table");

            migrationBuilder.DropColumn(
                name: "RecordCreationDate",
                table: "student_table");
        }
    }
}
