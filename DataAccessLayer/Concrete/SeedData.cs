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

            // Örnek iş ilanları
            var jobs = new List<JobPosting>
            {
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
                }
            };

            modelBuilder.Entity<JobPosting>().HasData(jobs);
        }
    }
} 