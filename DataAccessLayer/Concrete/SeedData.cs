using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Concrete
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Örnek kullanıcı
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    Password = "123456", // Gerçek uygulamada hash'lenmiş olmalı
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    IsEmployer = true,
                    CompanyName = "Admin Company",
                    Location = "İstanbul"
                }
            );

            // 30 farklı iş ilanı
            var jobs = new List<JobPosting>
            {
                // Teknoloji Sektörü - Yazılım Geliştirme
                new JobPosting
                {
                    Id = 1,
                    Title = "Senior .NET Developer",
                    CompanyName = "Tech Solutions A.Ş.",
                    Description = "Kurumsal müşterilerimiz için web uygulamaları geliştiren ekibimize katılacak, en az 5 yıl deneyimli .NET Developer arıyoruz.",
                    RequiredSkills = "C#, ASP.NET Core, SQL Server, Entity Framework, Azure",
                    RequiredExperience = 5,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 25000,
                    SalaryMax = 35000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 2,
                    Title = "Frontend Developer (React)",
                    CompanyName = "Digital Minds",
                    Description = "E-ticaret projelerimizde görev alacak, modern frontend teknolojilerine hakim React Developer arıyoruz.",
                    RequiredSkills = "React.js, TypeScript, Redux, REST API, CSS3",
                    RequiredExperience = 3,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 3,
                    Title = "DevOps Mühendisi",
                    CompanyName = "Cloud Systems",
                    Description = "Bulut altyapımızı yönetecek ve geliştirme süreçlerimizi iyileştirecek DevOps Mühendisi arıyoruz.",
                    RequiredSkills = "Docker, Kubernetes, AWS, CI/CD, Jenkins",
                    RequiredExperience = 4,
                    Location = "Ankara, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 30000,
                    SalaryMax = 45000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 4,
                    Title = "Python Backend Developer",
                    CompanyName = "AI Solutions",
                    Description = "Yapay zeka projelerimizde görev alacak, Python ve ML konularında deneyimli geliştirici arıyoruz.",
                    RequiredSkills = "Python, Django, Flask, Machine Learning, PostgreSQL",
                    RequiredExperience = 3,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 22000,
                    SalaryMax = 32000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 5,
                    Title = "Mobile Developer (Flutter)",
                    CompanyName = "Mobile Tech",
                    Description = "Cross-platform mobil uygulama geliştirme konusunda deneyimli Flutter Developer arıyoruz.",
                    RequiredSkills = "Flutter, Dart, Firebase, REST API, Git",
                    RequiredExperience = 2,
                    Location = "Antalya, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 18000,
                    SalaryMax = 28000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 6,
                    Title = "Java Spring Developer",
                    CompanyName = "Enterprise Solutions",
                    Description = "Büyük ölçekli kurumsal projelerde çalışacak Java Spring Developer arıyoruz.",
                    RequiredSkills = "Java, Spring Boot, Spring Security, MySQL, Maven",
                    RequiredExperience = 4,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 28000,
                    SalaryMax = 38000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 7,
                    Title = "Full Stack Developer (Node.js)",
                    CompanyName = "Web Innovations",
                    Description = "Modern web teknolojileri ile full stack uygulamalar geliştirecek developer arıyoruz.",
                    RequiredSkills = "Node.js, Express.js, MongoDB, React, TypeScript",
                    RequiredExperience = 3,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 22000,
                    SalaryMax = 32000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 8,
                    Title = "Data Scientist",
                    CompanyName = "Analytics Pro",
                    Description = "Büyük veri analizi ve makine öğrenmesi projelerinde çalışacak Data Scientist arıyoruz.",
                    RequiredSkills = "Python, R, SQL, Machine Learning, TensorFlow",
                    RequiredExperience = 4,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 35000,
                    SalaryMax = 50000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 9,
                    Title = "UI/UX Designer",
                    CompanyName = "Creative Design Studio",
                    Description = "Kullanıcı deneyimi odaklı tasarımlar yapacak UI/UX Designer arıyoruz.",
                    RequiredSkills = "Figma, Adobe XD, Sketch, Prototyping, User Research",
                    RequiredExperience = 3,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 10,
                    Title = "QA Test Engineer",
                    CompanyName = "Quality Assurance Ltd.",
                    Description = "Yazılım kalite güvencesi süreçlerinde görev alacak QA Engineer arıyoruz.",
                    RequiredSkills = "Selenium, JUnit, TestNG, API Testing, Agile",
                    RequiredExperience = 3,
                    Location = "Ankara, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 18000,
                    SalaryMax = 28000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Finans Sektörü
                new JobPosting
                {
                    Id = 11,
                    Title = "Finansal Analist",
                    CompanyName = "Global Finance",
                    Description = "Finansal analiz ve raporlama konularında deneyimli analist arıyoruz.",
                    RequiredSkills = "Excel, Financial Modeling, Risk Analysis, CFA",
                    RequiredExperience = 3,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 25000,
                    SalaryMax = 35000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 12,
                    Title = "Risk Yöneticisi",
                    CompanyName = "Risk Management Corp",
                    Description = "Kurumsal risk yönetimi konularında uzman risk yöneticisi arıyoruz.",
                    RequiredSkills = "Risk Assessment, Compliance, Banking Regulations, SAS",
                    RequiredExperience = 5,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 35000,
                    SalaryMax = 50000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Pazarlama Sektörü
                new JobPosting
                {
                    Id = 13,
                    Title = "Digital Marketing Manager",
                    CompanyName = "Digital Marketing Pro",
                    Description = "Dijital pazarlama stratejileri geliştirecek ve yönetecek manager arıyoruz.",
                    RequiredSkills = "Google Ads, Facebook Ads, SEO, Analytics, Content Marketing",
                    RequiredExperience = 4,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 22000,
                    SalaryMax = 32000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                new JobPosting
                {
                    Id = 14,
                    Title = "Content Creator",
                    CompanyName = "Content Studio",
                    Description = "Sosyal medya ve web için içerik üretecek creative content creator arıyoruz.",
                    RequiredSkills = "Copywriting, Social Media, Video Editing, Photoshop",
                    RequiredExperience = 2,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Yarı Zamanlı",
                    SalaryMin = 12000,
                    SalaryMax = 18000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // İnsan Kaynakları
                new JobPosting
                {
                    Id = 15,
                    Title = "HR Specialist",
                    CompanyName = "Human Resources Plus",
                    Description = "İnsan kaynakları süreçlerini yönetecek HR uzmanı arıyoruz.",
                    RequiredSkills = "Recruitment, Employee Relations, HRIS, Labor Law",
                    RequiredExperience = 3,
                    Location = "Ankara, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 18000,
                    SalaryMax = 25000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Satış Sektörü
                new JobPosting
                {
                    Id = 16,
                    Title = "Sales Manager",
                    CompanyName = "Sales Solutions",
                    Description = "B2B satış süreçlerini yönetecek ve ekibi yönlendirecek sales manager arıyoruz.",
                    RequiredSkills = "B2B Sales, CRM, Negotiation, Team Leadership",
                    RequiredExperience = 5,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 25000,
                    SalaryMax = 40000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Eğitim Sektörü
                new JobPosting
                {
                    Id = 17,
                    Title = "Eğitim Koordinatörü",
                    CompanyName = "Education Center",
                    Description = "Eğitim programlarını koordine edecek ve öğretmen ekibini yönetecek koordinatör arıyoruz.",
                    RequiredSkills = "Curriculum Development, Teacher Training, Educational Technology",
                    RequiredExperience = 4,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Sağlık Sektörü
                new JobPosting
                {
                    Id = 18,
                    Title = "Sağlık Yöneticisi",
                    CompanyName = "Healthcare Management",
                    Description = "Sağlık kurumlarının yönetim süreçlerini yönetecek sağlık yöneticisi arıyoruz.",
                    RequiredSkills = "Healthcare Administration, Medical Terminology, Management",
                    RequiredExperience = 5,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 30000,
                    SalaryMax = 45000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Lojistik Sektörü
                new JobPosting
                {
                    Id = 19,
                    Title = "Lojistik Uzmanı",
                    CompanyName = "Logistics Solutions",
                    Description = "Tedarik zinciri ve lojistik süreçlerini optimize edecek uzman arıyoruz.",
                    RequiredSkills = "Supply Chain Management, SAP, Warehouse Management",
                    RequiredExperience = 3,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Müşteri Hizmetleri
                new JobPosting
                {
                    Id = 20,
                    Title = "Müşteri Hizmetleri Müdürü",
                    CompanyName = "Customer Service Pro",
                    Description = "Müşteri hizmetleri ekibini yönetecek ve müşteri memnuniyetini artıracak müdür arıyoruz.",
                    RequiredSkills = "Customer Service, Team Management, CRM, Communication",
                    RequiredExperience = 4,
                    Location = "Ankara, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 22000,
                    SalaryMax = 32000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Hukuk Sektörü
                new JobPosting
                {
                    Id = 21,
                    Title = "Hukuk Müşaviri",
                    CompanyName = "Legal Consulting",
                    Description = "Kurumsal hukuk konularında danışmanlık yapacak hukuk müşaviri arıyoruz.",
                    RequiredSkills = "Corporate Law, Contract Law, Legal Research, Turkish Law",
                    RequiredExperience = 6,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 40000,
                    SalaryMax = 60000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Mimarlık ve Tasarım
                new JobPosting
                {
                    Id = 22,
                    Title = "İç Mimar",
                    CompanyName = "Interior Design Studio",
                    Description = "Konut ve ofis projelerinde iç mimari tasarımları yapacak iç mimar arıyoruz.",
                    RequiredSkills = "AutoCAD, 3D Max, SketchUp, Interior Design",
                    RequiredExperience = 3,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 18000,
                    SalaryMax = 28000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Medya ve İletişim
                new JobPosting
                {
                    Id = 23,
                    Title = "Sosyal Medya Uzmanı",
                    CompanyName = "Social Media Agency",
                    Description = "Markaların sosyal medya hesaplarını yönetecek ve içerik stratejileri geliştirecek uzman arıyoruz.",
                    RequiredSkills = "Social Media Management, Content Creation, Analytics, Photoshop",
                    RequiredExperience = 2,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 15000,
                    SalaryMax = 25000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Çevre ve Sürdürülebilirlik
                new JobPosting
                {
                    Id = 24,
                    Title = "Çevre Mühendisi",
                    CompanyName = "Environmental Solutions",
                    Description = "Çevre koruma ve sürdürülebilirlik projelerinde çalışacak çevre mühendisi arıyoruz.",
                    RequiredSkills = "Environmental Engineering, Waste Management, Sustainability",
                    RequiredExperience = 3,
                    Location = "Ankara, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Turizm Sektörü
                new JobPosting
                {
                    Id = 25,
                    Title = "Turizm Yöneticisi",
                    CompanyName = "Tourism Management",
                    Description = "Otel ve turizm işletmelerinin yönetim süreçlerini yönetecek turizm yöneticisi arıyoruz.",
                    RequiredSkills = "Hotel Management, Tourism Marketing, Customer Service",
                    RequiredExperience = 4,
                    Location = "Antalya, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 18000,
                    SalaryMax = 28000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // E-ticaret
                new JobPosting
                {
                    Id = 26,
                    Title = "E-ticaret Uzmanı",
                    CompanyName = "E-commerce Solutions",
                    Description = "Online satış platformlarını yönetecek ve e-ticaret stratejileri geliştirecek uzman arıyoruz.",
                    RequiredSkills = "E-commerce Platforms, Digital Marketing, Analytics, Shopify",
                    RequiredExperience = 3,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 20000,
                    SalaryMax = 30000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Güvenlik
                new JobPosting
                {
                    Id = 27,
                    Title = "Siber Güvenlik Uzmanı",
                    CompanyName = "Cyber Security Pro",
                    Description = "Kurumsal siber güvenlik süreçlerini yönetecek ve güvenlik açıklarını tespit edecek uzman arıyoruz.",
                    RequiredSkills = "Network Security, Penetration Testing, Security Tools, CISSP",
                    RequiredExperience = 4,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 35000,
                    SalaryMax = 50000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Araştırma ve Geliştirme
                new JobPosting
                {
                    Id = 28,
                    Title = "Ar-Ge Mühendisi",
                    CompanyName = "R&D Innovation",
                    Description = "Yeni ürün ve teknoloji geliştirme projelerinde çalışacak Ar-Ge mühendisi arıyoruz.",
                    RequiredSkills = "Research Methods, Product Development, Innovation, Technical Writing",
                    RequiredExperience = 4,
                    Location = "İzmir, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 25000,
                    SalaryMax = 35000,
                    IsRemote = false,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Proje Yönetimi
                new JobPosting
                {
                    Id = 29,
                    Title = "Proje Yöneticisi",
                    CompanyName = "Project Management Solutions",
                    Description = "Büyük ölçekli projeleri yönetecek ve ekipleri koordine edecek proje yöneticisi arıyoruz.",
                    RequiredSkills = "Project Management, Agile, Scrum, Risk Management, PMP",
                    RequiredExperience = 5,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Tam Zamanlı",
                    SalaryMin = 30000,
                    SalaryMax = 45000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                },
                // Stajyer Pozisyonu
                new JobPosting
                {
                    Id = 30,
                    Title = "Yazılım Geliştirici Stajyeri",
                    CompanyName = "Tech Startup",
                    Description = "Yazılım geliştirme alanında staj yapmak isteyen öğrenciler arıyoruz.",
                    RequiredSkills = "Basic Programming, Learning Ability, Team Work, Communication",
                    RequiredExperience = 0,
                    Location = "İstanbul, Türkiye",
                    EmploymentType = "Staj",
                    SalaryMin = 5000,
                    SalaryMax = 8000,
                    IsRemote = true,
                    IsActive = true,
                    IsFilled = false,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(1)
                }
            };

            modelBuilder.Entity<JobPosting>().HasData(jobs);
        }
    }
} 