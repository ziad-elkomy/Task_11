using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int SpecializationId { get; set; }
        [ForeignKey(nameof(SpecializationId))]
        public Specialization Specialization { get; set; }
    }
}
