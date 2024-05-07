using System.ComponentModel.DataAnnotations;

namespace CollageV2.Models
{
    public class Exam
    {
        [Key]
        public int Ex_Id { get; set; }

        public string? TypeExam { get; set; }   
        public string? CourseName { get; set; }

        public string? Duration { get; set; }

        public int? Time { get; set; }
        public int CurrentQS { get; set; }
        public int? NumOfQs { get; set; }
        public DateTime? Date { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
       

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
