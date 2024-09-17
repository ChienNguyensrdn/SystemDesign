using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    role = table.Column<int>(type: "int", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    createAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_User",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cabs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    driverId = table.Column<long>(type: "bigint", nullable: true),
                    type = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    regNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    cabId = table.Column<long>(type: "bigint", nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    locationLatitude = table.Column<double>(type: "float", nullable: true),
                    locationLongitude = table.Column<double>(type: "float", nullable: true),
                    createAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    userId = table.Column<long>(name: "userId ", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Driver_Cab",
                        column: x => x.cabId,
                        principalTable: "cabs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Driver_User",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    tripId = table.Column<long>(type: "bigint", nullable: true),
                    method = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    createAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: true),
                    driverId = table.Column<long>(type: "bigint", nullable: true),
                    paymentId = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    sourceLatitude = table.Column<double>(type: "float", nullable: true),
                    sourceLongitude = table.Column<double>(type: "float", nullable: true),
                    destinationLatitude = table.Column<double>(type: "float", nullable: true),
                    destinationLongitude = table.Column<double>(type: "float", nullable: true),
                    createAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trip_Customer",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Trip_Driver",
                        column: x => x.driverId,
                        principalTable: "drivers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Trip_Payment",
                        column: x => x.paymentId,
                        principalTable: "payments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: true),
                    driverId = table.Column<long>(type: "bigint", nullable: true),
                    tripId = table.Column<long>(type: "bigint", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    feedback = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rating_Customer",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rating_Driver",
                        column: x => x.driverId,
                        principalTable: "drivers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rating_Trip",
                        column: x => x.tripId,
                        principalTable: "trips",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cabs_driverId",
                table: "cabs",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_userId",
                table: "customers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_drivers_cabId",
                table: "drivers",
                column: "cabId");

            migrationBuilder.CreateIndex(
                name: "IX_drivers_userId ",
                table: "drivers",
                column: "userId ");

            migrationBuilder.CreateIndex(
                name: "IX_payments_tripId",
                table: "payments",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_customerId",
                table: "ratings",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_driverId",
                table: "ratings",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_tripId",
                table: "ratings",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_customerId",
                table: "trips",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_driverId",
                table: "trips",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_paymentId",
                table: "trips",
                column: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cab_Driver",
                table: "cabs",
                column: "driverId",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Trip",
                table: "payments",
                column: "tripId",
                principalTable: "trips",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cab_Driver",
                table: "cabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Driver",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Trip",
                table: "payments");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "cabs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
