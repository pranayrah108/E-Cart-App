using System.ComponentModel.DataAnnotations;

namespace server.Dto
{
    public class RegisterUserReqDto
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public string Address { get; set; } = "";

    }
}
