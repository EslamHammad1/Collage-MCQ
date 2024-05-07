using CollageV2.DataEF;
using CollageV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemCollageV1.DTO;

namespace CollageV2.Services
{
    public class StudentService : IStudentService
    { 
        private readonly CollageContext _context;
        private long _MaxImageSizeAllowed = 10485760;
        private new List<string> _ValidExtensions = new List<string> { ".jpg , .png" };
        public StudentService(CollageContext context) 
        {
        _context = context;
        }

        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.students.ToListAsync();
            return new ObjectResult(students);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.students.FindAsync(id);
                 return new OkObjectResult(student);

        }

        public async Task<IActionResult> CreateStudent(StudentDTO stDTO)
        {
            if (string.IsNullOrEmpty(stDTO.Full_Name))
                return new BadRequestObjectResult("Name is Required !");
            if (stDTO.St_IDCode== null)
                return new BadRequestObjectResult("IDCode is Required !");
            if (string.IsNullOrEmpty(stDTO.Department))
                return new BadRequestObjectResult("Department is Required !");
            if (string.IsNullOrEmpty(stDTO.Level))
                return new BadRequestObjectResult("Level is Required !");
            if (string.IsNullOrEmpty(stDTO.Email))
                return new BadRequestObjectResult("Email is Required !");
            if (stDTO.Image == null)
                return new BadRequestObjectResult("Image is Required !");
            if (stDTO.Image.Length > _MaxImageSizeAllowed)
                return new BadRequestObjectResult("Max allowed size for image is 10 MB! ");

            // Convert image to byte array
            byte[] imageData;
            using (var dataStream = new MemoryStream())
            {
                await stDTO.Image.CopyToAsync(dataStream);
                imageData = dataStream.ToArray();
            }

            var newStudent = new Student
            {
                S_FullName = stDTO.Full_Name,
                St_IDCode = stDTO.St_IDCode,
                Department = stDTO.Department,
                Level = stDTO.Level,
                Email = stDTO.Email,
                Image = imageData // Assign the byte array to the Image property
            };

            _context.students.Add(newStudent);
            await _context.SaveChangesAsync();

            return new OkObjectResult(newStudent);
        }

        public async Task<IActionResult> UpdateStudent(int id,[FromForm] StudentDTO stDTO)
        {
            var existingStudent = await _context.students.FindAsync(id);
            if (existingStudent == null)
                return new NotFoundObjectResult("Student not found.");

            // Update student properties if provided in the DTO
            if (!string.IsNullOrEmpty(stDTO.Full_Name))
                existingStudent.S_FullName = stDTO.Full_Name;
            //if (stDTO.code!=null)
            //    existingStudent.St_IDCode = stDTO.St_IDCode;
            if (!string.IsNullOrEmpty(stDTO.Department))
                existingStudent.Department = stDTO.Department;
            if (!string.IsNullOrEmpty(stDTO.Level))
                existingStudent.Level = stDTO.Level;
            if (!string.IsNullOrEmpty(stDTO.Email))
                existingStudent.Email = stDTO.Email;
            if (stDTO.Image != null)
            {
                // Validate image size
                if (stDTO.Image.Length > _MaxImageSizeAllowed)
                    return new BadRequestObjectResult("Max allowed size for image is 10 MB! ");

                // Convert image to byte array
                using (var dataStream = new MemoryStream())
                {
                    await stDTO.Image.CopyToAsync(dataStream);
                    existingStudent.Image = dataStream.ToArray();
                }
            }
            existingStudent.St_IDCode = stDTO.St_IDCode;

            await _context.SaveChangesAsync();

            return new OkObjectResult(existingStudent);
        }
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _context.students.FindAsync(id);
            if (existingStudent == null)
                return new NotFoundObjectResult("Student not found.");

            _context.students.Remove(existingStudent);
            await _context.SaveChangesAsync();

            return new OkObjectResult(existingStudent);
        }
    }
}
