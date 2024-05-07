using System.ComponentModel.DataAnnotations;

namespace CollageV2.Models
{
    public class Admin
    {
        [Key]
        public int A_Id { get; set; }
        public float Ad_IDCode { get; set; }

        public string AD_FullName { get; set; } 

        public string Department { get; set; }
        public byte[] Image { get; set; }

        public string Email { get; set; }

    }
}
