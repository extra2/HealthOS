using System;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{
    public class CustomStatisticsData
    {
        [Key]
        public int Id { get; set; }
        public virtual CustomStatistics CustomStatistics { get; set; }
        public double FirstMeasurement { get; set; }
        public double SecondMeasurement { get; set; }
        public bool IsSecondMeasurementUsed { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}
