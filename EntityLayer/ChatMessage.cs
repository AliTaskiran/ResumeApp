using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int? UserId { get; set; }

        public bool IsFromBot { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
