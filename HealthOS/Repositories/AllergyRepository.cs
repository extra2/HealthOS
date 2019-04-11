using System.Linq;
using HealthOS.Data;
using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public class AllergyRepository : IAllergyRepository
    {
        private ApplicationDbContext Context;

        public AllergyRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(Allergy allergy)
        {
            Context.Allergies.Add(allergy);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.Allergies.FirstOrDefault(a => a.Id == id);
            if(itemToRemove == null) return;
            Context.Allergies.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}