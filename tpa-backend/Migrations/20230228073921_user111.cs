using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpa_backend.Migrations
{
    /// <inheritdoc />
    public partial class user111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "Difficulties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Difficulties_PlanId",
                table: "Difficulties",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Difficulties_Plans_PlanId",
                table: "Difficulties",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Difficulties_Plans_PlanId",
                table: "Difficulties");

            migrationBuilder.DropIndex(
                name: "IX_Difficulties_PlanId",
                table: "Difficulties");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Difficulties");
        }
    }
}
