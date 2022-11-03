using System;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.Auth
{
        public record RegisterUserDto([Required] string Name, [Required] string Surname,
            [Required] string Email, [Required] string Password, [Required] DateTime BirthDate);
}
