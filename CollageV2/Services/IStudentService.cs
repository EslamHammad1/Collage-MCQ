using CollageV2.Models;
using Microsoft.AspNetCore.Mvc;
using SystemCollageV1.DTO;

namespace CollageV2.Services
{
    public interface IStudentService 
    {
        Task<IActionResult> GetAllStudents();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> CreateStudent(StudentDTO stDTO);
        Task<IActionResult> UpdateStudent(int id, StudentDTO stDTO);
        Task<IActionResult> DeleteStudent(int id);
    }
}
