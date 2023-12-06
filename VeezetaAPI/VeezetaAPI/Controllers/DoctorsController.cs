using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using VeezetaAPI.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace VeezetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private new List<string> _allowedExtensions = new List<string> { ".jpg", "png" };
        private long alowedImageSize = 2097152;
        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(doctors);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromForm] CreateDoctorDto dto)
        {
            if(dto.image.Length > alowedImageSize)
                return BadRequest(error: "The maximum allowed size for image is 2MB ");
            if (!_allowedExtensions.Contains(Path.GetExtension(dto.image.FileName).ToLower()))
                return BadRequest(error: "Only .jpg and .png images are allowed ");
 
            using var dataStream = new MemoryStream();
            await dto.image.CopyToAsync(dataStream); 
            var doctor = new Doctor
            {

                fullName = dto.fullName,
                image = dataStream.ToArray(), 
                email = dto.email,
                gender = dto.gender,
                phone = dto.phone,
                specialization = dto.specialization,
            };
            await _context.AddAsync(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }
    }
}
