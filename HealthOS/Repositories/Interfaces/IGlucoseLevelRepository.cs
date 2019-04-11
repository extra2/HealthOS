using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public interface IGlucoseLevelRepository
    {
        void Add(GlucoseLevelStatistics statistics);
        void Remove(int id);
    }
}