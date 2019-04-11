using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public interface IDrugsRepository
    {
        void Add(Drug drug);
        void Delete(int id);
        void Update(DrugUpdateViewModel value, int id);
    }
}