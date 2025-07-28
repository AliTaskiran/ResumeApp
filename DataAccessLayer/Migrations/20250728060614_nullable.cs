using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resumes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3801), new DateTime(2025, 8, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3821), new DateTime(2025, 8, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3828), new DateTime(2025, 8, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3834), new DateTime(2025, 8, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3835) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3839), new DateTime(2025, 8, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 9, 6, 12, 966, DateTimeKind.Local).AddTicks(3222));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resumes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6657), new DateTime(2025, 8, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6669), new DateTime(2025, 8, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6673), new DateTime(2025, 8, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6676), new DateTime(2025, 8, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6681), new DateTime(2025, 8, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 9, 5, 3, 257, DateTimeKind.Local).AddTicks(6397));
        }
    }
}
