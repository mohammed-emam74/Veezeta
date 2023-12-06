namespace VeezetaAPI.Dtos
{
    public class CreateDoctorDto
    {
        public int Id { get; set; }
        [MaxLength(length: 50)]
        public string fullName { get; set; }
        public IFormFile image {get; set; }
        public string email { get; set; }
        public bool gender { get; set; }
        public string phone { get; set; }
        public string specialization { get; set; }
    }
}
