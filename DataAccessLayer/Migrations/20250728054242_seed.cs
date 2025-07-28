using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyDescription", "CompanyName", "CompanyWebsite", "CreatedDate", "Email", "FirstName", "IsActive", "IsEmployer", "LastName", "Location", "Password", "PhoneNumber" },
                values: new object[] { 1, null, "Admin Company", null, new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4297), "admin@example.com", "Admin", true, true, "User", "İstanbul", "123456", null });

            migrationBuilder.InsertData(
                table: "JobPostings",
                columns: new[] { "Id", "CompanyName", "CreatedDate", "Description", "EmploymentType", "ExpiryDate", "IsActive", "IsFilled", "IsRemote", "LastModifiedDate", "Location", "RequiredExperience", "RequiredSkills", "SalaryMax", "SalaryMin", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Tech Solutions A.Ş.", new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4502), "Kurumsal müşterilerimiz için web uygulamaları geliştiren ekibimize katılacak, en az 5 yıl deneyimli .NET Developer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4503), true, false, true, null, "İstanbul, Türkiye", 5, "C#, ASP.NET Core, SQL Server, Entity Framework, Azure", 35000m, 25000m, "Senior .NET Developer", 1 },
                    { 2, "Digital Minds", new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4517), "E-ticaret projelerimizde görev alacak, modern frontend teknolojilerine hakim React Developer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4518), true, false, true, null, "İzmir, Türkiye", 3, "React.js, TypeScript, Redux, REST API, CSS3", 30000m, 20000m, "Frontend Developer (React)", 1 },
                    { 3, "Cloud Systems", new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4521), "Bulut altyapımızı yönetecek ve geliştirme süreçlerimizi iyileştirecek DevOps Mühendisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4522), true, false, true, null, "Ankara, Türkiye", 4, "Docker, Kubernetes, AWS, CI/CD, Jenkins", 45000m, 30000m, "DevOps Mühendisi", 1 },
                    { 4, "AI Solutions", new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4525), "Yapay zeka projelerimizde görev alacak, Python ve ML konularında deneyimli geliştirici arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4525), true, false, true, null, "İstanbul, Türkiye", 3, "Python, Django, Flask, Machine Learning, PostgreSQL", 32000m, 22000m, "Python Backend Developer", 1 },
                    { 5, "Mobile Tech", new DateTime(2025, 7, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4529), "Cross-platform mobil uygulama geliştirme konusunda deneyimli Flutter Developer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 8, 42, 41, 656, DateTimeKind.Local).AddTicks(4529), true, false, true, null, "Antalya, Türkiye", 2, "Flutter, Dart, Firebase, REST API, Git", 28000m, 18000m, "Mobile Developer (Flutter)", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
