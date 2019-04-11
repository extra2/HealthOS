using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthOS.Models;
using HealthOS.Models.Statistics;
using HealthOS.Services;

namespace HealthOS.ViewModels
{
    public class CustomStatisticsViewModel
    {
        public List<CustomStatisticsViewDetails> CustomStatistics { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string MonthName { get; set; }
        public string ChartDataPoints { get; set; }
        public int PageNumber { get; set; }
    }
}
