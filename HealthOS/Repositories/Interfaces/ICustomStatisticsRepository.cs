using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public interface ICustomStatisticsRepository
    {
        void AddMeasurement(CustomStatisticsData statisticsData, int customStatisticsId);
        void AddNewStatistic(CustomStatistics statistic);
        void RemoveMeasurement(int id);
        void RemoveStatistic(int id);
    }
}