using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpa_backend.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landmark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    VisitTime = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinAge = table.Column<int>(type: "int", nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    DifficultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landmark_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Landmark_Difficulty_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlanDifficulty = table.Column<float>(type: "real", nullable: true),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plan_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tourist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestLandmark",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    LandmarksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLandmark", x => new { x.InterestsId, x.LandmarksId });
                    table.ForeignKey(
                        name: "FK_InterestLandmark_Interest_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLandmark_Landmark_LandmarksId",
                        column: x => x.LandmarksId,
                        principalTable: "Landmark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitCost_Landmark_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeekDay = table.Column<int>(type: "int", nullable: true),
                    LandmarkWorkingHoursId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_Landmark_LandmarkWorkingHoursId",
                        column: x => x.LandmarkWorkingHoursId,
                        principalTable: "Landmark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Day_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovingTypePlan",
                columns: table => new
                {
                    MovingTypesId = table.Column<int>(type: "int", nullable: false),
                    PlansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingTypePlan", x => new { x.MovingTypesId, x.PlansId });
                    table.ForeignKey(
                        name: "FK_MovingTypePlan_MovingType_MovingTypesId",
                        column: x => x.MovingTypesId,
                        principalTable: "MovingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingTypePlan_Plan_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLandmark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VisitTime = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ObligitaryVisit = table.Column<bool>(type: "bit", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLandmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLandmark_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestTourist",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    TouristsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestTourist", x => new { x.InterestsId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_InterestTourist_Interest_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestTourist_Tourist_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandmarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObligitaryVisit = table.Column<bool>(type: "bit", nullable: true),
                    VisitTime = table.Column<int>(type: "int", nullable: true),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Landmark_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmark",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Day_LandmarkWorkingHoursId",
                table: "Day",
                column: "LandmarkWorkingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_PlanId",
                table: "Day",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLandmark_LandmarksId",
                table: "InterestLandmark",
                column: "LandmarksId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestTourist_TouristsId",
                table: "InterestTourist",
                column: "TouristsId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmark_CityId",
                table: "Landmark",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmark_DifficultyId",
                table: "Landmark",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingTypePlan_PlansId",
                table: "MovingTypePlan",
                column: "PlansId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLandmark_PlanId",
                table: "PersonalLandmark",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_CityId",
                table: "Plan",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_DayId",
                table: "TimeSlot",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_LandmarkId",
                table: "TimeSlot",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_UserId",
                table: "Tourist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitCost_LandmarkId",
                table: "VisitCost",
                column: "LandmarkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLandmark");

            migrationBuilder.DropTable(
                name: "InterestTourist");

            migrationBuilder.DropTable(
                name: "MovingTypePlan");

            migrationBuilder.DropTable(
                name: "PersonalLandmark");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "VisitCost");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Tourist");

            migrationBuilder.DropTable(
                name: "MovingType");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Landmark");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
