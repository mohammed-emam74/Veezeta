using System.ComponentModel.DataAnnotations;

namespace VeezetaAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(length:50)]
        public string fullName { get; set; }
        public  byte[] image { get; set; }
        public string email { get; set; }
        public bool gender { get; set; }
        public string phone { get; set; }
        public string specialization { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ICollection<Patient> Patients { get; set; }

    }
}
