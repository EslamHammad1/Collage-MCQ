using SystemCollageV1.Models;

namespace SystemCollageV1.DTO
{
    public class StudentDTO
    {

        public string ? Full_Name { get; set; }
        public float St_IDCode { get; set; }
        public IFormFile? Image { get; set; }
        public string? Level { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
    }
}
