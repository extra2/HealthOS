using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public interface IBloodPressureRepository
    {
        void Add(BloodPressureStatistics statistics);
        void Remove(int id);
    }
}