using System.Linq;
using HealthOS.Data;
using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public class WeightRepository : IWeightRepository
    {
        private ApplicationDbContext Context { get; set; }

        public WeightRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(WeightStatistics statistics)
        {
            Context.Weights.Add(statistics);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.Weights.First(b => b.Id == id);
            Context.Weights.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}