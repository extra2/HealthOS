using System.Collections.Generic;
using HealthOS.Models;

namespace HealthOS.ViewModels
{
    public class AuthorizedDoctoraViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<Relation> Relations { get; set; }
    }
}
