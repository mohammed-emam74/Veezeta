using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;

namespace VeezetaAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public byte[]? image { get; set; } 
        public bool gender { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ICollection<Doctor>Doctors { get; set; }


    }
}
