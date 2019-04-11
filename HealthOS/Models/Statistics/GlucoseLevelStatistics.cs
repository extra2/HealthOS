using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{
    public class GlucoseLevelStatistics
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Glucose { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}