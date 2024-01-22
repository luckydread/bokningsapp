using System.ComponentModel.DataAnnotations;

namespace bokningsapp.Dtos
{
    public class LoginRequest
    {
        [MinLength(Consts.UsernameMinLength, ErrorMessage = Consts.UsernameLengthValidationError)]
        public string? UserName { get; set; }

        [RegularExpression(Consts.PasswordRegex, ErrorMessage = Consts.PasswordValidationError)]
        public string? Password { get; set; }
    }

}
