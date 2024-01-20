using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Maripiell.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    DiscountAmount = table.Column<double>(type: "double", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DiscountAmount", "IsDeleted", "MinAmount", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "10OFF", 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3935), 0.10000000000000001, false, 5000, 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3943) },
                    { 2, "20OFF", 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3948), 0.20000000000000001, false, 10000, 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3948) },
                    { 3, "30OFF", 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3949), 0.29999999999999999, false, 15000, 1, new DateTime(2024, 1, 17, 20, 46, 35, 233, DateTimeKind.Local).AddTicks(3950) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
