using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class MatchHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResumeId { get; set; }

        [Required]
        public int JobPostingId { get; set; }

        public double MatchScore { get; set; }

        public string MatchDetails { get; set; }
        public bool IsNotified { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
