using System.ComponentModel.DataAnnotations;

namespace Tej_WebApp_Core.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter User ID")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Please enter User Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
