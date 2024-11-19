using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDemoForGuid.Models;
using StudentDemoForGuid.Services;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoForGuid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var existingStudent = _studentService.Get(id);
            return Ok(existingStudent);
        }

        [HttpPost] 
        public async Task<IActionResult> AddStudent(Student student) 
        { 
            if (!ModelState.IsValid) 
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)); 
                throw new ValidationException($"{errors}"); 
            } 
            _studentService.Add(student); 
            return Ok(student); 
        }

    }
}
