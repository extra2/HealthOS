using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{
    public class WeightStatistics
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Weight { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}