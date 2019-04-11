using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class Allergy
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Value { get; set; }
    }
}