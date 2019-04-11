using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.ViewModels
{
    public class NextDoctorVisitViewModel
    {
        public List<NextDoctorVisit> NextDoctorVisits { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
