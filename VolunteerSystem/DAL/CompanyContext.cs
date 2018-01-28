using VolunteerSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace VolunteerSystem.DAL
{
  
        public class CompanyContext : DbContext
        {

            public CompanyContext() : base("CompanyContext")
            {
            }

            public DbSet<Volunteer> Volunteers { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }
            public DbSet<Job> Jobs { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}