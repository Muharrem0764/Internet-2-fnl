using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vize.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
