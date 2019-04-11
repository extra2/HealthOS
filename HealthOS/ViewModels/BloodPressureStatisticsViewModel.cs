using System.Collections.Generic;
using HealthOS.Models.Statistics;

namespace HealthOS.Models
{
    public class BloodPressureStatisticsViewModel
    {
        public List<BloodPressureStatistics> BloodPreasureStatistics { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string MonthName { get; set; }
        public string ChartDataPoints { get; set; }
        public int PageNumber { get; set; }
    }
}
