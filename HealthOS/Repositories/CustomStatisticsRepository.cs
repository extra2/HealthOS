using HealthOS.Data;
using HealthOS.Models.Statistics;
using HealthOS.Repositories.Interfaces;
using System.Linq;

namespace HealthOS.Repositories
{
    public class CustomStatisticsRepository : ICustomStatisticsRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomStatisticsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMeasurement(CustomStatisticsData statisticsData, int customStatisticsId)
        {
            var customStatistics = _context.CustomStatistics.First(c => c.Id == customStatisticsId);
            statisticsData.CustomStatistics = customStatistics;
            customStatistics.CustomStatisticsDatas.Add(statisticsData);
            _context.CustomStatisticsDatas.Add(statisticsData);
            _context.SaveChanges();
        }

        public void AddNewStatistic(CustomStatistics statistic)
        {
            _context.CustomStatistics.Add(statistic);
            _context.SaveChanges();
        }

        public void RemoveMeasurement(int id)
        {
            _context.CustomStatisticsDatas.Remove(_context.CustomStatisticsDatas.First(c => c.Id == id));
            _context.SaveChanges();
        }

        public void RemoveStatistic(int id)
        {
            var measurementsToRemove = _context.CustomStatisticsDatas.Where(c => c.CustomStatistics.Id == id);
            if (measurementsToRemove.Any()) _context.CustomStatisticsDatas.RemoveRange(measurementsToRemove);
            _context.Remove(_context.CustomStatistics.First(c => c.Id == id));
            _context.SaveChanges();
        }
    }
}
