using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpa_backend.Migrations
{
    /// <inheritdoc />
    public partial class mew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { new Guid("974e51d5-afab-44c0-9fa7-dd08b39491ee"), "email", "Evgeniya", "8980" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("974e51d5-afab-44c0-9fa7-dd08b39491ee"));
        }
    }
}
