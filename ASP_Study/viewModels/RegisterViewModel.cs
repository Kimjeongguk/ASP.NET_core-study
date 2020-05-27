using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Study.viewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="값을 입력해주세요."), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "값을 입력해주세요.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "값을 입력해주세요.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "값을 입력해주세요."),DataType(DataType.Password)]
        public string Password { get; set; }
       [DataType(DataType.Password), Compare("Password",ErrorMessage ="비밀번호가 일치하지 않습니다.")]
        public string ConfirmPassword { get; set; }

    }
}
