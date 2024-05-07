using CollageV2.DataEF;
using CollageV2.Models;
using CollageV2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
using SystemCollageV1.DTO;
using SystemCollageV1.Models;

namespace SystemCollageV1.Controllers
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
        public async Task<IActionResult> GetAllStudent()

        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }
        

        [HttpPost]
        public async Task <IActionResult> PostStudent([FromForm] StudentDTO stDTO)
        {
            var Student = await _studentService.CreateStudent(stDTO);
            return Ok(Student);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateStudent(int id, Student student)
        //{
        //    var existingStudent = _context.students.FirstOrDefault(s => s.S_Id == id);
        //    if (existingStudent == null)
        //    {
        //        return NotFound("Student not found.");
        //    }

        //    existingStudent.S_FullName = student.S_FullName;
        //    // Update other properties as needed

        //    _context.SaveChanges();
        //    return Ok("Student updated successfully.");
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var existingStudent = _context.students.FirstOrDefault(s => s.S_Id == id);
        //    if (existingStudent == null)
        //    {
        //        return NotFound("Student not found.");
        //    }

        //    _context.students.Remove(existingStudent);
        //    _context.SaveChanges();
        //    return Ok("Student deleted successfully.");
        //}
    }
}
