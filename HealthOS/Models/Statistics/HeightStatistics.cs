using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{

    public class HeightStatistics
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Height { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}
