using System.ComponentModel.DataAnnotations;

namespace CollageV2.Models
{
    public class Result
    {
        [Key]
        public int Result_Id { get; set; } 

        public int Ex_Id { get; set; }

        public int S_Id { get; set; }

        public int Grade { get; set; }

        public virtual Exam Ex { get; set; } 

        public virtual Student St { get; set; } 
    }
}
