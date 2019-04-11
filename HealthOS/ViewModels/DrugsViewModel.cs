using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.ViewModels
{
    public class DrugsViewModel
    {
        public List<Drug> Drugs { get; set; }
        public ApplicationUser User { get; set; }
        public List<string> DrugsReminder { get; set; }
    }
}
