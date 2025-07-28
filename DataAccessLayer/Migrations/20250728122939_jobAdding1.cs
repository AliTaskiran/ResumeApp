using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class jobAdding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "JobPostings",
                columns: new[] { "Id", "CompanyName", "CreatedDate", "Description", "EmploymentType", "ExpiryDate", "IsActive", "IsFilled", "IsRemote", "LastModifiedDate", "Location", "RequiredExperience", "RequiredSkills", "SalaryMax", "SalaryMin", "Title", "UserId" },
                values: new object[,]
                {
                    { 6, "Enterprise Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3716), "Büyük ölçekli kurumsal projelerde çalışacak Java Spring Developer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3717), true, false, false, null, "İstanbul, Türkiye", 4, "Java, Spring Boot, Spring Security, MySQL, Maven", 38000m, 28000m, "Java Spring Developer", 1 },
                    { 7, "Web Innovations", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3720), "Modern web teknolojileri ile full stack uygulamalar geliştirecek developer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3721), true, false, true, null, "İzmir, Türkiye", 3, "Node.js, Express.js, MongoDB, React, TypeScript", 32000m, 22000m, "Full Stack Developer (Node.js)", 1 },
                    { 8, "Analytics Pro", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3724), "Büyük veri analizi ve makine öğrenmesi projelerinde çalışacak Data Scientist arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3724), true, false, true, null, "İstanbul, Türkiye", 4, "Python, R, SQL, Machine Learning, TensorFlow", 50000m, 35000m, "Data Scientist", 1 },
                    { 9, "Creative Design Studio", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3729), "Kullanıcı deneyimi odaklı tasarımlar yapacak UI/UX Designer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3729), true, false, true, null, "İstanbul, Türkiye", 3, "Figma, Adobe XD, Sketch, Prototyping, User Research", 30000m, 20000m, "UI/UX Designer", 1 },
                    { 10, "Quality Assurance Ltd.", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3734), "Yazılım kalite güvencesi süreçlerinde görev alacak QA Engineer arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3734), true, false, false, null, "Ankara, Türkiye", 3, "Selenium, JUnit, TestNG, API Testing, Agile", 28000m, 18000m, "QA Test Engineer", 1 },
                    { 11, "Global Finance", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3737), "Finansal analiz ve raporlama konularında deneyimli analist arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3738), true, false, false, null, "İstanbul, Türkiye", 3, "Excel, Financial Modeling, Risk Analysis, CFA", 35000m, 25000m, "Finansal Analist", 1 },
                    { 12, "Risk Management Corp", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3741), "Kurumsal risk yönetimi konularında uzman risk yöneticisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3742), true, false, false, null, "İstanbul, Türkiye", 5, "Risk Assessment, Compliance, Banking Regulations, SAS", 50000m, 35000m, "Risk Yöneticisi", 1 },
                    { 13, "Digital Marketing Pro", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3746), "Dijital pazarlama stratejileri geliştirecek ve yönetecek manager arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3747), true, false, true, null, "İstanbul, Türkiye", 4, "Google Ads, Facebook Ads, SEO, Analytics, Content Marketing", 32000m, 22000m, "Digital Marketing Manager", 1 },
                    { 14, "Content Studio", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3751), "Sosyal medya ve web için içerik üretecek creative content creator arıyoruz.", "Yarı Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3751), true, false, true, null, "İzmir, Türkiye", 2, "Copywriting, Social Media, Video Editing, Photoshop", 18000m, 12000m, "Content Creator", 1 },
                    { 15, "Human Resources Plus", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3755), "İnsan kaynakları süreçlerini yönetecek HR uzmanı arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3755), true, false, false, null, "Ankara, Türkiye", 3, "Recruitment, Employee Relations, HRIS, Labor Law", 25000m, 18000m, "HR Specialist", 1 },
                    { 16, "Sales Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3759), "B2B satış süreçlerini yönetecek ve ekibi yönlendirecek sales manager arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3759), true, false, false, null, "İstanbul, Türkiye", 5, "B2B Sales, CRM, Negotiation, Team Leadership", 40000m, 25000m, "Sales Manager", 1 },
                    { 17, "Education Center", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3763), "Eğitim programlarını koordine edecek ve öğretmen ekibini yönetecek koordinatör arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3763), true, false, false, null, "İzmir, Türkiye", 4, "Curriculum Development, Teacher Training, Educational Technology", 30000m, 20000m, "Eğitim Koordinatörü", 1 },
                    { 18, "Healthcare Management", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3837), "Sağlık kurumlarının yönetim süreçlerini yönetecek sağlık yöneticisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3837), true, false, false, null, "İstanbul, Türkiye", 5, "Healthcare Administration, Medical Terminology, Management", 45000m, 30000m, "Sağlık Yöneticisi", 1 },
                    { 19, "Logistics Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3842), "Tedarik zinciri ve lojistik süreçlerini optimize edecek uzman arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3842), true, false, false, null, "İstanbul, Türkiye", 3, "Supply Chain Management, SAP, Warehouse Management", 30000m, 20000m, "Lojistik Uzmanı", 1 },
                    { 20, "Customer Service Pro", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3846), "Müşteri hizmetleri ekibini yönetecek ve müşteri memnuniyetini artıracak müdür arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3847), true, false, false, null, "Ankara, Türkiye", 4, "Customer Service, Team Management, CRM, Communication", 32000m, 22000m, "Müşteri Hizmetleri Müdürü", 1 },
                    { 21, "Legal Consulting", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3851), "Kurumsal hukuk konularında danışmanlık yapacak hukuk müşaviri arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3851), true, false, false, null, "İstanbul, Türkiye", 6, "Corporate Law, Contract Law, Legal Research, Turkish Law", 60000m, 40000m, "Hukuk Müşaviri", 1 },
                    { 22, "Interior Design Studio", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3854), "Konut ve ofis projelerinde iç mimari tasarımları yapacak iç mimar arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3855), true, false, false, null, "İzmir, Türkiye", 3, "AutoCAD, 3D Max, SketchUp, Interior Design", 28000m, 18000m, "İç Mimar", 1 },
                    { 23, "Social Media Agency", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3858), "Markaların sosyal medya hesaplarını yönetecek ve içerik stratejileri geliştirecek uzman arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3859), true, false, true, null, "İstanbul, Türkiye", 2, "Social Media Management, Content Creation, Analytics, Photoshop", 25000m, 15000m, "Sosyal Medya Uzmanı", 1 },
                    { 24, "Environmental Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3862), "Çevre koruma ve sürdürülebilirlik projelerinde çalışacak çevre mühendisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3863), true, false, false, null, "Ankara, Türkiye", 3, "Environmental Engineering, Waste Management, Sustainability", 30000m, 20000m, "Çevre Mühendisi", 1 },
                    { 25, "Tourism Management", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3867), "Otel ve turizm işletmelerinin yönetim süreçlerini yönetecek turizm yöneticisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3868), true, false, false, null, "Antalya, Türkiye", 4, "Hotel Management, Tourism Marketing, Customer Service", 28000m, 18000m, "Turizm Yöneticisi", 1 },
                    { 26, "E-commerce Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3871), "Online satış platformlarını yönetecek ve e-ticaret stratejileri geliştirecek uzman arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3871), true, false, true, null, "İstanbul, Türkiye", 3, "E-commerce Platforms, Digital Marketing, Analytics, Shopify", 30000m, 20000m, "E-ticaret Uzmanı", 1 },
                    { 27, "Cyber Security Pro", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3876), "Kurumsal siber güvenlik süreçlerini yönetecek ve güvenlik açıklarını tespit edecek uzman arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3876), true, false, true, null, "İstanbul, Türkiye", 4, "Network Security, Penetration Testing, Security Tools, CISSP", 50000m, 35000m, "Siber Güvenlik Uzmanı", 1 },
                    { 28, "R&D Innovation", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3880), "Yeni ürün ve teknoloji geliştirme projelerinde çalışacak Ar-Ge mühendisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3880), true, false, false, null, "İzmir, Türkiye", 4, "Research Methods, Product Development, Innovation, Technical Writing", 35000m, 25000m, "Ar-Ge Mühendisi", 1 },
                    { 29, "Project Management Solutions", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3884), "Büyük ölçekli projeleri yönetecek ve ekipleri koordine edecek proje yöneticisi arıyoruz.", "Tam Zamanlı", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3884), true, false, true, null, "İstanbul, Türkiye", 5, "Project Management, Agile, Scrum, Risk Management, PMP", 45000m, 30000m, "Proje Yöneticisi", 1 },
                    { 30, "Tech Startup", new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3888), "Yazılım geliştirme alanında staj yapmak isteyen öğrenciler arıyoruz.", "Staj", new DateTime(2025, 8, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3888), true, false, true, null, "İstanbul, Türkiye", 0, "Basic Programming, Learning Ability, Team Work, Communication", 8000m, 5000m, "Yazılım Geliştirici Stajyeri", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 28, 15, 29, 38, 823, DateTimeKind.Local).AddTicks(3457));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: 30);

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
    }
}
