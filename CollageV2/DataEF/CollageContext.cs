using CollageV2.Models;
using Microsoft.EntityFrameworkCore;
using SystemCollageV1.Models;

namespace CollageV2.DataEF
{
    public class CollageContext : DbContext
    {
       
        public CollageContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Option> options { get; set; }
        public DbSet<Result> results { get; set; }
    }
}
