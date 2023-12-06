using Microsoft.EntityFrameworkCore;

namespace VeezetaAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(x => x.Patients)
                .WithMany(y => y.Doctors)
                .UsingEntity(j => j.ToTable("DoctorPatient"));

        }
    }
}
