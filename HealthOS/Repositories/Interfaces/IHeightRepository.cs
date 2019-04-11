using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public interface IHeightRepository
    {
        void Add(HeightStatistics statistics);
        void Remove(int id);
    }
}