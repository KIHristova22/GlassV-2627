using Microsoft.AspNetCore.Mvc;
using GlassV_2627.Data;
using GlassV_2627.Models;
using GlassV_2627.StudentDTOs;

namespace GlassV_2627.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _context.Teachers.ToList();
            return Ok(teachers);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeacherEditDTO teacherDto)
        {
            Teacher entity = new Teacher();

            entity.Name = teacherDto.Name;
            entity.Subject = teacherDto.Subject;

            _context.Teachers.Add(entity);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}