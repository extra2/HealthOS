using System.Linq;
using HealthOS.Data;
using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public class GlucoseLevelRepository : IGlucoseLevelRepository
    {
        private ApplicationDbContext Context { get; set; }

        public GlucoseLevelRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(GlucoseLevelStatistics statistics)
        {
            Context.GlucoseLevels.Add(statistics);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.GlucoseLevels.First(b => b.Id == id);
            Context.GlucoseLevels.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}