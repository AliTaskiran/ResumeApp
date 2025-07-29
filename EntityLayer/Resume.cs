using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string FilePath { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        public string ParsedContent { get; set; }

        [StringLength(500)]
        public string Skills { get; set; }

        public string Experience { get; set; }
        public string Education { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(200)]
        public string? LinkedInProfile { get; set; }

        [StringLength(200)]
        public string? GithubProfile { get; set; }

        public bool IsMainResume { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
