using System.Collections.Generic;
using System.Linq;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Models.HelperModels;
using HealthOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthOS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext Context { get; set; }
        public UserRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public ApplicationUser Get(string id)
        {
            return Context.Users.First(u => u.Id == id);
        }
        public ApplicationUser GetWithBloodPressure(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.BloodPressureStatistics).First();
        }
        public ApplicationUser GetWithBloodGlucoseLevel(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.GlucoseStatistics).First();
        }

        public ApplicationUser GetWithDrugs(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.Drugs).First();
        }

        public ApplicationUser GetWithCustomStatistics(string id)
        {
            var user = Context.Users.Where(u => u.Id == id).Include(u => u.CustomStatistics).First();
            user.CustomStatistics = Context.CustomStatistics.Where(c => c.ApplicationUser.Id == id)
                .Include(s => s.CustomStatisticsDatas).ToList();
            return user;
        }

        public ApplicationUser GetWithDiseasesAndAllergies(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.Diseases).Include(u => u.Allergies).First();
        }

        public ApplicationUser GetWithHeight(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.HeightStatistics).First();
        }
        public ApplicationUser GetWithWeight(string id)
        {
            return Context.Users.Where(u => u.Id == id).Include(u => u.WeightStatistics).First();
        }

        public void Update(string id, ApplicationUserUpdateModel value)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return;
            user.Name = value.Name;
            user.Surname = value.Surname;
            user.Birthday = value.Birthday;
            user.BloodType = value.BloodType;
            user.Gender = value.Gender;
            Context.SaveChanges();
        }

        public List<Relation> GetAuthorizedDoctors(string id)
        {
            return Context.Relations.Where(r => r.AuthorizedPatients.Id == id).Include(u => u.AuthorizedDoctors).ToList();
        }
        public List<Relation> GetAuthorizedPatients(string id)
        {
            return Context.Relations.Where(r => r.AuthorizedDoctors.Id == id).Include(u => u.AuthorizedPatients).ToList();
        }

        public bool AddRelation(RelationsModel value, string patientId)
        {
            var doctor = Context.Users.FirstOrDefault(u => u.isDoctor == true && u.InvitationCode == value.AuthorizationNumber);
            if (doctor == null) return false;
            var patient = Context.Users.First(u => u.Id == patientId);
            if (Context.Relations.FirstOrDefault(p => p.AuthorizedDoctors == doctor && p.AuthorizedPatients == patient) != null)
            { // relation exists
                return false;
            }
            Context.Relations.Add(new Relation()
            {
                AuthorizedDoctors = doctor,
                AuthorizedPatients = patient
            });
            Context.SaveChanges();
            return true;
        }

        public void DeleteRelation(int id)
        {
            var relation = Context.Relations.FirstOrDefault(r => r.Id == id);
            if (relation == null) return;
            Context.Relations.Remove(relation);
            Context.SaveChanges();
        }

        public List<ApplicationUser> GetMyPatients(string id)
        {
            var relations = Context.Relations.Where(u => u.AuthorizedDoctors.Id == id).Include(a => a.AuthorizedDoctors).Include(b => b.AuthorizedPatients).ToList();
            var userList = new List<ApplicationUser>();
            relations.ForEach(r => userList.Add(Get(r.AuthorizedPatients.Id)));
            return userList;
        }

        public ApplicationUser GetAllMyPatientData(string patientId)
        {
            var user = Context.Users.Where(u => u.Id == patientId)
                .Include(i => i.Allergies)
                .Include(i => i.Diseases)
                .Include(i => i.Drugs)
                .Include(i => i.BloodPressureStatistics)
                .Include(i => i.GlucoseStatistics)
                .Include(i => i.HeightStatistics)
                .Include(i => i.WeightStatistics)
                .First();
            if (user.Allergies != null) user.Allergies = user.Allergies.OrderBy(a => a.Value).ToList();
            if (user.Diseases != null) user.Diseases = user.Diseases.OrderByDescending(a => a.StartDate).ToList();
            if (user.Drugs != null) user.Drugs = user.Drugs.OrderBy(a => a.Name).ToList();
            if (user.BloodPressureStatistics != null) user.BloodPressureStatistics = user.BloodPressureStatistics.OrderByDescending(a => a.MeasurementDate).ToList();
            if (user.GlucoseStatistics != null) user.GlucoseStatistics = user.GlucoseStatistics.OrderByDescending(a => a.MeasurementDate).ToList();
            if (user.HeightStatistics != null) user.HeightStatistics = user.HeightStatistics.OrderByDescending(a => a.MeasurementDate).ToList();
            if (user.WeightStatistics != null) user.WeightStatistics = user.WeightStatistics.OrderByDescending(a => a.MeasurementDate).ToList();
            return user;
        }
    }
}