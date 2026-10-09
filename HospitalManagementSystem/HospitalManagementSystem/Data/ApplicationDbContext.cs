using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace HospitalManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;initial catalog = HospitalSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
