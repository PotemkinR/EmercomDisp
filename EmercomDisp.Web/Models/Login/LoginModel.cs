using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Login
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="Login")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}