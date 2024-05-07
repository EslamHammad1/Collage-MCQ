using System.ComponentModel.DataAnnotations;

namespace CollageV2.Models
{
    public class Student
    {
        [Key]
        public int S_Id { get; set; }      
        public string? S_FullName { get; set; } 
        public string? Department { get; set; }
        public byte[] Image { get; set; }
        public string? Level { get; set; } 

        public float St_IDCode { get; set; }
        public string? Email { get; set; } 

    }
}
