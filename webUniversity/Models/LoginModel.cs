using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class LoginModel
    {
        public string login { get; set; }

        [DataType(DataType.Password)]

        public string password { get; set; }
    }
}
