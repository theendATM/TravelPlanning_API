using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpa_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    VisitTime = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinAge = table.Column<int>(type: "int", nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    NorthernLatitude = table.Column<float>(type: "real", nullable: true),
                    EasternLatitude = table.Column<float>(type: "real", nullable: true),
                    DifficultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landmarks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Landmarks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
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
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tourists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_InterestLandmark_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLandmark_Landmarks_LandmarksId",
                        column: x => x.LandmarksId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitCosts",
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
                    table.PrimaryKey("PK_VisitCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitCosts_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Days",
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
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Landmarks_LandmarkWorkingHoursId",
                        column: x => x.LandmarkWorkingHoursId,
                        principalTable: "Landmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
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
                        name: "FK_MovingTypePlan_MovingTypes_MovingTypesId",
                        column: x => x.MovingTypesId,
                        principalTable: "MovingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingTypePlan_Plans_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLandmarks",
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
                    table.PrimaryKey("PK_PersonalLandmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLandmarks_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
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
                        name: "FK_InterestTourist_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestTourist_Tourists_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
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
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Landmarks_LandmarkId",
                        column: x => x.LandmarkId,
                        principalTable: "Landmarks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Москва" });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Очень низкий уровень сложности" },
                    { 2, "Низкий уровень сложности" },
                    { 3, "Средний уровень сложности" },
                    { 4, "Высокий уровень сложности" },
                    { 5, "Очень высокий уровень сложности" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Художественные музеи" },
                    { 2, "Исторические музеи" },
                    { 3, "Научные музеи" },
                    { 4, "Музеи естественной истории" },
                    { 5, "Технические музеи" },
                    { 6, "Музеи культуры" },
                    { 7, "Археологические места" },
                    { 8, "Крепости и замки" },
                    { 9, "Памятники архитектуры" },
                    { 10, "Памятники" },
                    { 11, "Религиозные места" },
                    { 12, "Памятники воинской и трудовой славы" },
                    { 13, "Национальные парки" },
                    { 14, "Заповедники" },
                    { 15, "Водопады" },
                    { 16, "Горы" },
                    { 17, "Водоемы" },
                    { 18, "Пляжи" },
                    { 19, "Парки развлечений" },
                    { 20, "Аквапарки" },
                    { 21, "Современные здания" },
                    { 22, "Экстремальные места" },
                    { 23, "Фестивали" },
                    { 24, "Театры" },
                    { 25, "Выставки" }
                });

            migrationBuilder.InsertData(
                table: "MovingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Пешком" },
                    { 2, "Общественный транспорт" },
                    { 3, "Такси" },
                    { 4, "Личный автомобиль" },
                    { 5, "Самокат" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { new Guid("504e5073-8054-4f58-952b-e6d592fb993f"), "email", "Evgeniya", "8980" });

            migrationBuilder.CreateIndex(
                name: "IX_Days_LandmarkWorkingHoursId",
                table: "Days",
                column: "LandmarkWorkingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_PlanId",
                table: "Days",
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
                name: "IX_Landmarks_CityId",
                table: "Landmarks",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_DifficultyId",
                table: "Landmarks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingTypePlan_PlansId",
                table: "MovingTypePlan",
                column: "PlansId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLandmarks_PlanId",
                table: "PersonalLandmarks",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_CityId",
                table: "Plans",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DayId",
                table: "TimeSlots",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_LandmarkId",
                table: "TimeSlots",
                column: "LandmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourists_UserId",
                table: "Tourists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitCosts_LandmarkId",
                table: "VisitCosts",
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
                name: "PersonalLandmarks");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "VisitCosts");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "MovingTypes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
