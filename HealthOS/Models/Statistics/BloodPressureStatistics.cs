using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{
    public class BloodPressureStatistics
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}
