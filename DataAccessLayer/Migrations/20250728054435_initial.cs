using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9521), new DateTime(2025, 8, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9534), new DateTime(2025, 8, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9534) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9538), new DateTime(2025, 8, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9541), new DateTime(2025, 8, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9545), new DateTime(2025, 8, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 8, 44, 34, 845, DateTimeKind.Local).AddTicks(9325));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4502), new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4503) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4517), new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4521), new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4525), new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4529), new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4297));
        }
    }
}
