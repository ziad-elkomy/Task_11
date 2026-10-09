namespace HospitalManagementSystem.ViewModels
{
    public class AppVM
    {
        public int AppId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
