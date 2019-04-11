using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class NextDoctorVisit
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string DoctorName { get; set; }
        public DateTime VisitTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}