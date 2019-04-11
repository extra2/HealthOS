using System.Linq;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Repositories.Interfaces;

namespace HealthOS.Repositories
{
    public class DrugsRepository : IDrugsRepository
    {
        private ApplicationDbContext Context { get; set; }
        public DrugsRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Add(Drug drug)
        {
            Context.Drugs.Add(drug);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemToRemove = Context.Drugs.FirstOrDefault(d => d.Id == id);
            if(itemToRemove == null) return;
            Context.Drugs.Remove(itemToRemove);
            Context.SaveChanges();
        }

        public void Update(DrugUpdateViewModel drug, int id)
        {
            var drugFromDb = Context.Drugs.FirstOrDefault(d => d.Id == id);
            if(drugFromDb == null) return;
            drugFromDb.Day1 = drug.Day1;
            drugFromDb.Day2 = drug.Day2;
            drugFromDb.Day3 = drug.Day3;
            drugFromDb.Day4 = drug.Day4;
            drugFromDb.Day5 = drug.Day5;
            drugFromDb.Day6 = drug.Day6;
            drugFromDb.Day7 = drug.Day7;
            drugFromDb.Name = drug.Name;
            drugFromDb.Amount = drug.Amount;
            drugFromDb.ConsumptionMethod = drug.ConsumptionMethod;
            Context.SaveChanges();
        }
    }
}
