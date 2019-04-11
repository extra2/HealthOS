using System.Collections.Generic;
using HealthOS.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace HealthOS.Repositories.Interfaces
{
    public interface IDiseaseRepository
    {
        Disease Get(int id);
        IEnumerable<Disease> Get();
        void Add(Disease disease);
        void Update(Disease disease, int id);
        void Remove(int id);
    }
}