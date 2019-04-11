using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.Repositories.Interfaces
{
    public interface IVisitsRepository
    {
        List<NextDoctorVisit> GetDoctorVisits(string patientId);
        void DeleteVisit(int id);
        void Add(NextDoctorVisit visit, string userId);
        void Update(NextDoctorVisit visit, int id);
    }
}