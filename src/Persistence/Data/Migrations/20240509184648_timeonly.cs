using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobCandidateHub.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class timeonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "best_call_time",
                table: "candidates",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "best_call_time",
                table: "candidates",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);
        }
    }
}
