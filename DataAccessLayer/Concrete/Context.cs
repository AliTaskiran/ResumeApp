using Microsoft.EntityFrameworkCore;
using EntityLayer;  // Entity'lerin namespace'i
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        // Constructor ekleyelim ki connection string'i dışarıdan alabilelim
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // Parametsiz constructor development için
        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-0CSOJOE;Database=JobPortalDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=true;Integrated Security=true;",
                    options => options.EnableRetryOnFailure()
                );
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<MatchHistory> MatchHistories { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablo isimleri
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Resume>().ToTable("Resumes");
            modelBuilder.Entity<JobPosting>().ToTable("JobPostings");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplications");
            modelBuilder.Entity<MatchHistory>().ToTable("MatchHistories");
            modelBuilder.Entity<ChatMessage>().ToTable("ChatMessages");

            // Decimal tipleri için hassasiyet ayarları
            modelBuilder.Entity<JobPosting>()
                .Property(j => j.SalaryMin)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<JobPosting>()
                .Property(j => j.SalaryMax)
                .HasColumnType("decimal(18,2)");

            // İlişkiler
            modelBuilder.Entity<Resume>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobPosting>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne<JobPosting>()
                .WithMany()
                .HasForeignKey(ja => ja.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne<Resume>()
                .WithMany()
                .HasForeignKey(ja => ja.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchHistory>()
                .HasOne<Resume>()
                .WithMany()
                .HasForeignKey(mh => mh.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchHistory>()
                .HasOne<JobPosting>()
                .WithMany()
                .HasForeignKey(mh => mh.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatMessage>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            SeedData.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}