using System.ComponentModel.DataAnnotations;

namespace SocialNet.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        [StringLength(10,MinimumLength=4,ErrorMessage="Password Length should be between 4 to 10 ")]
        public string password { get; set; }
    }
}