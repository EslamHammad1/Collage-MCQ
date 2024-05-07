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

        [HttpGet("{id:int}")]
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

        [HttpPut("{id:int}")]
        public async  Task<IActionResult> UpdateStudent(int id , [FromForm] StudentDTO stDTO)
        {
            var NewStudent = _studentService.UpdateStudent(id ,stDTO );
            return Ok(NewStudent);
        }

       [HttpDelete("{id:int}")]
       public async Task<IActionResult> DeleteStudent(int id)
       {
            var Student =await _studentService.DeleteStudent(id);
           return Ok("Student deleted successfully.");
       }
    }
}
