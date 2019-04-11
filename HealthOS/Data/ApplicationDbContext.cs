using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthOS.Models;
using HealthOS.Models.Statistics;

namespace HealthOS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BloodPressureStatistics> BloodPreasures { get; set; }
        public DbSet<GlucoseLevelStatistics> GlucoseLevels { get; set; }
        public DbSet<WeightStatistics> Weights { get; set; }
        public DbSet<HeightStatistics> Heights { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<NextDoctorVisit> NextDoctorVisits { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<CustomStatistics> CustomStatistics { get; set; }
        public DbSet<CustomStatisticsData> CustomStatisticsDatas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
