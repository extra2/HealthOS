using System.Collections.Generic;
using HealthOS.Models;
using HealthOS.Models.HelperModels;

namespace HealthOS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser Get(string id);
        ApplicationUser GetWithBloodPressure(string id);
        ApplicationUser GetWithHeight(string id);
        ApplicationUser GetWithWeight(string id);
        ApplicationUser GetWithBloodGlucoseLevel(string id);
        ApplicationUser GetWithDrugs(string id);
        ApplicationUser GetWithCustomStatistics(string id);
        ApplicationUser GetWithDiseasesAndAllergies(string id);
        void Update(string id, ApplicationUserUpdateModel value);
        List<Relation> GetAuthorizedDoctors(string id);
        List<Relation> GetAuthorizedPatients(string id);
        bool AddRelation(RelationsModel value, string patientId);
        void DeleteRelation(int id);
        List<ApplicationUser> GetMyPatients(string id);
        ApplicationUser GetAllMyPatientData(string patientId);
    }
}