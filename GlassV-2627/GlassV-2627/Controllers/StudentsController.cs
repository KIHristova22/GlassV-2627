using GlassV_2627.Data;
using GlassV_2627.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlassV_2627.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Student> students = _context.Students.ToList();
        return Ok(students);
    }

    [HttpGet]
    public IActionResult GetOneStudent([FromQuery] int id)
    {
        var student = _context.Students.Where(x => x.Id == id).First();
        return Ok(student);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] StudentEditDTO student)
    {
        Student entity = new Student();

        entity.FirstName = student.FirstName;
        entity.LastName = student.LastName;
        entity.Age = student.Age;
        entity.UserName = student.UserName;
        entity.Grade = 0;

        _context.Students.Add(entity);
        _context.SaveChanges();
            
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        Student studentTodelete = _context.Students.Where(x => x.Id == id).First();
        _context.Students.Remove(studentTodelete);
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateGrade([FromQuery] int id, [FromQuery] int grade)
    {
        Student studentToPath = _context.Students.Where(x => x.Id == id).First();
        _context.SaveChanges();
        return Ok();
    }
}