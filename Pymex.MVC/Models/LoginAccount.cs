using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Pymex.MVC.Models
{
    public class LoginAccount
    {
        private string _username;
        private string _password;

        [Display(Name = "username")]
        [Required(ErrorMessage = "Por favor, ingrese su nombre de usuario")]
        public string Username { get => _username; set => _username = value; }

        [Display(Name = "contraseña")]
        [Required(ErrorMessage = "Por favor, ingrese su contraseña")]
        public string Password { get => _password; set => _password = ConvertToHash256(value); }

        private string ConvertToHash256(string pass)
        {
            if (string.IsNullOrEmpty(pass))
                return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var stringBuilder = new StringBuilder();
                bytes.ForEach(x => stringBuilder.Append(x.ToString("x2")));
                return stringBuilder.ToString();
            }
        }
    }
}