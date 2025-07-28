using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class JobPosting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RequiredSkills { get; set; }

        public int RequiredExperience { get; set; }

        public string Location { get; set; }

        public string EmploymentType { get; set; } // Full-time, Part-time, Contract, etc.

        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }

        public bool IsRemote { get; set; }
        public bool IsActive { get; set; }
        public bool IsFilled { get; set; }

        public int UserId { get; set; } // İlanı yayınlayan kullanıcı

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
