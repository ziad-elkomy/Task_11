using System.ComponentModel.DataAnnotations;
namespace HospitalManagementSystem.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
