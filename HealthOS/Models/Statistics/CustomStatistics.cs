using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models.Statistics
{
    public class CustomStatistics
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<CustomStatisticsData> CustomStatisticsDatas { get; set; }
        public string StatisticsName { get; set; }
    }
}
