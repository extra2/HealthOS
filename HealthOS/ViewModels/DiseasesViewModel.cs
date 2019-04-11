using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.ViewModels
{
    public class DiseasesViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Allergy> Allergies { get; set; }
    }
}
