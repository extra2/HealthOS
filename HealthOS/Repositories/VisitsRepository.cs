using System.Collections.Generic;
using System.Linq;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Repositories.Interfaces;

namespace HealthOS.Repositories
{
    public class VisitsRepository : IVisitsRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NextDoctorVisit> GetDoctorVisits(string patientId)
        {
            var visits = _context.NextDoctorVisits
                .Where(p => p.ApplicationUser.Id == patientId && p.ApplicationUser.isPatient).ToList();
            return visits;
        }

        public void DeleteVisit(int id)
        {
            var visitToRemove = _context.NextDoctorVisits.FirstOrDefault(w => w.Id == id);
            if(visitToRemove == null) return;
            _context.NextDoctorVisits.Remove(visitToRemove);
            _context.SaveChanges();
        }

        public void Add(NextDoctorVisit visit, string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);  
            if(user == null) return;
            visit.ApplicationUser = user;
            _context.NextDoctorVisits.Add(visit);
            _context.SaveChanges();
        }

        public void Update(NextDoctorVisit visit, int id)
        {
            var oldVisit = _context.NextDoctorVisits.FirstOrDefault(w => w.Id == id);
            if (oldVisit == null) return;
            oldVisit.Description = visit.Description;
            oldVisit.DoctorName = visit.DoctorName;
            oldVisit.Location = visit.Location;
            oldVisit.VisitTime = visit.VisitTime;
            _context.SaveChanges();
        }
    }
}
