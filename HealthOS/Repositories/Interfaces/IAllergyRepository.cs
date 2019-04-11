using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public interface IAllergyRepository
    {
        void Add(Allergy allergy);
        void Remove(int id);
    }
}