using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int JobPostingId { get; set; }

        [Required]
        public int ResumeId { get; set; }

        public string CoverLetter { get; set; }
        public int Status { get; set; }

        [StringLength(500)]
        public string? FeedbackNotes { get; set; }

        public double? MatchScore { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
