using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; }
    }
}
