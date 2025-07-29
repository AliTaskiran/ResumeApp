using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _2907 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Resumes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5430), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5443), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5447), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5447) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5450), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5451) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5454), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5454) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5460), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5464), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5465) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5469), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5473), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5477), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5481), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5485), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5488), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5492), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5492) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5496), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5500), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5505), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5505) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5510), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5510) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5514), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5518), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5518) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5521), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5522) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5526), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5526) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5529), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5533), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5536), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5539), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5543), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5546), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5549), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5553), new DateTime(2025, 8, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5553) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 29, 9, 55, 0, 423, DateTimeKind.Local).AddTicks(5162));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Resumes");

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3685), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3698), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3699) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3702), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3703) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3706), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3707) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3710), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3716), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3720), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3724), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3729), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3734), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3737), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3741), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3746), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3751), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3755), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3755) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3759), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3759) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3763), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3837), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3842), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3846), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3851), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3854), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3858), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3862), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3863) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3867), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3871), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3871) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3876), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3876) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3880), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3884), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3888), new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3888) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3457));
        }
    }
}
