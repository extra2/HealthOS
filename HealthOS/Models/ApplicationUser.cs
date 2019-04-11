using System;
using System.Collections.Generic;
using HealthOS.Models.Statistics;
using Microsoft.AspNetCore.Identity;

namespace HealthOS.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool isPatient { get; set; }
        public bool isDoctor { get; set; }
        public string InvitationCode { get; set; }
        public virtual ICollection<BloodPressureStatistics> BloodPressureStatistics { get; set; }
        public virtual ICollection<GlucoseLevelStatistics> GlucoseStatistics { get; set; }
        public virtual ICollection<HeightStatistics> HeightStatistics { get; set; }
        public virtual ICollection<WeightStatistics> WeightStatistics { get; set; }
        public virtual ICollection<CustomStatistics> CustomStatistics { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<NextDoctorVisit> NextDoctorVisits { get; set; }
    }
}
