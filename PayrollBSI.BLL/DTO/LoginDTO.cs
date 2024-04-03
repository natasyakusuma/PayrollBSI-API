using System.ComponentModel.DataAnnotations;

namespace PayrollBSI.BLL.DTO
{
    public class LoginDTO
    {
        [Required]
        [StringLength(50)]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Token { get; set; }
    }
}
