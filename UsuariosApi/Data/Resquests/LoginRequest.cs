using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Resquests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
