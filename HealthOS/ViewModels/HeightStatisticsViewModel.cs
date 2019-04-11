using System.Collections.Generic;
using HealthOS.Models.Statistics;

namespace HealthOS.Models.ViewModels
{
    public class HeightStatisticsViewModel
    {
        public List<HeightStatistics> HeightStatistics { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string MonthName { get; set; }
        public string ChartDataPoints { get; set; }
        public int PageNumber { get; set; }
    }
}
