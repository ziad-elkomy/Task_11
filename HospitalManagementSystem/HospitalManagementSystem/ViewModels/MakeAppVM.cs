namespace HospitalManagementSystem.ViewModels
{
    public class MakeAppVM
    {
        public int DoctorId { get; set; }
        public bool IsValid { get; set; }
        public bool IsSubmit { get; set; }
        public string ErrMessage { get; set; }
    }
}
