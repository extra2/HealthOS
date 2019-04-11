using System.Collections.Generic;
using System.Linq;
using HealthOS.Data;
using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private ApplicationDbContext Context { get; set; }

        public DiseaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public Disease Get(int id)
        {
            return Context.Diseases.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Disease> Get()
        {
            return Context.Diseases.ToList();
        }

        public void Add(Disease disease)
        {
            Context.Diseases.Add(disease);
            Context.SaveChanges();
        }

        public void Update(Disease disease, int id)
        {
            var itemToUpdate = Context.Diseases.FirstOrDefault(d => d.Id == id);
            if (itemToUpdate == null) return;
            itemToUpdate.Description = disease.Description;
            itemToUpdate.Name = disease.Name;
            itemToUpdate.StartDate = disease.StartDate;
            itemToUpdate.EndDate = disease.EndDate;
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.Diseases.FirstOrDefault(d => d.Id == id);
            if(itemToRemove == null)return;
            Context.Diseases.Remove(itemToRemove);
            Context.SaveChanges();
        }
    }
}