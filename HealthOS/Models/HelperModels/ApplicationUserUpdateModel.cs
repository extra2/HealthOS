using System;

namespace HealthOS.Models
{
    public class ApplicationUserUpdateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}