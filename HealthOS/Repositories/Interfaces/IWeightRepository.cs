using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public interface IWeightRepository
    {
        void Add(WeightStatistics statistics);
        void Remove(int id);
    }
}