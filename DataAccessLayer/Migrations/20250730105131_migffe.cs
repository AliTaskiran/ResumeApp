using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migffe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistories");

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9655), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9668), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9672), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9676), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9680), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9686), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9686) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9691), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9694), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9698), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9703), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9707), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9712), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9716), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9720), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9724), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9727), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9728) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9731), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9737), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9741), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9741) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9744), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9748), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9752), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9756), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9760), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9764), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9768), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9772), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9776), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9779), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9784), new DateTime(2025, 8, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 30, 13, 51, 30, 574, DateTimeKind.Local).AddTicks(9456));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotified = table.Column<bool>(type: "bit", nullable: false),
                    JobPostingId = table.Column<int>(type: "int", nullable: false),
                    MatchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchScore = table.Column<double>(type: "float", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchHistories_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchHistories_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistories_JobPostingId",
                table: "MatchHistories",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistories_ResumeId",
                table: "MatchHistories",
                column: "ResumeId");
        }
    }
}
