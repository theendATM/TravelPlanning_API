using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using tpa_backend.Models;

namespace tpa_backend.DTOModels
{
    public class UserViewDTO
    {
        /*[JsonPropertyName("id")]
        public Guid Id { get; set; }*/

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("tourists")]
        public List<Tourist>? Tourists { get; set; }

        [JsonPropertyName("plans")]
        public List<Plan>? Plans { get; set; }
    }

    public class UserCreateEditDTO
    {

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage ="Минимальная длина пароля 6 символов")]
        public string Password { get; set; }

        [JsonPropertyName("password-confirmed")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConmirmed { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class AuthRequest
    {
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}
