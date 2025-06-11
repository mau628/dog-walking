using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog.Infrastructure.DataStore.Migrations
{
    /// <inheritdoc />
    public partial class switchfromtimespantoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Walks");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Walks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Walks");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Walks",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
