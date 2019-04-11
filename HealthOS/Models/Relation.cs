using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser AuthorizedDoctors { get; set; }
        public virtual ApplicationUser AuthorizedPatients { get; set; }
    }
}