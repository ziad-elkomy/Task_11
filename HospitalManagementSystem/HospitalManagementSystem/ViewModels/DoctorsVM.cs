using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.ViewModels
{
    public class DoctorsVM
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
