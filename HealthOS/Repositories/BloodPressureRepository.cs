using System.Linq;
using HealthOS.Data;
using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public class BloodPressureRepository : IBloodPressureRepository
    {
        private ApplicationDbContext Context { get; set; }

        public BloodPressureRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(BloodPressureStatistics statistics)
        {
            Context.BloodPreasures.Add(statistics);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.BloodPreasures.First(b => b.Id == id);
            Context.BloodPreasures.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}