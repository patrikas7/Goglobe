using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.Auth
{
    public record RegisterAdminDto([Required] string Name, [Required] string Surname,
          [Required] string Email, [Required] string Password);
}
