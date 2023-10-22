using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBooking.Model.Migrations
{
    public partial class ratings_table_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingStars = table.Column<int>(type: "integer", nullable: false),
                    NumberOfLikes = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    DateOfRating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AppUserId",
                table: "Ratings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RestaurantId",
                table: "Ratings",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
