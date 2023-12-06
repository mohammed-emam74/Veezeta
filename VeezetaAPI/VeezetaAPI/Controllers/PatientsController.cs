using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeezetaAPI.Dtos;
using VeezetaAPI.Models;

namespace VeezetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private new List<string> _allowedExtensions = new List<string> { ".jpg", "png" };
        private long alowedImageSize = 2097152;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PatientDto dto)
        {
            var patient = new Patient
            {
                fullName = dto.fullName,
                gender = dto.gender,
                email = dto.email,
                image = dto.image,
                phone = dto.phone,
                dateOfBirth = dto.dateOfBirth,
                Doctors = dto.Doctors,
            };
            await _context.AddAsync(patient);
            _context.SaveChanges();
            return Ok(patient);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients);
        }
    }
}
