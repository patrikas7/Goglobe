using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.Agencies
{
    public record CreateAgencyDTO([Required] string Name, [Required] string Address, string Logo);
}
