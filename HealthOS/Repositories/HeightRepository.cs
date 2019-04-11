using System.Linq;
using HealthOS.Data;
using HealthOS.Models.Statistics;

namespace HealthOS.Repositories.Interfaces
{
    public class HeightRepository : IHeightRepository
    {
        private ApplicationDbContext Context { get; set; }

        public HeightRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(HeightStatistics statistics)
        {
            Context.Heights.Add(statistics);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.Heights.First(b => b.Id == id);
            Context.Heights.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}