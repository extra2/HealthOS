using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser UserFrom{ get; set; }
        public virtual ApplicationUser UserTo { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; }
        public bool Seen { get; set; }
    }
}