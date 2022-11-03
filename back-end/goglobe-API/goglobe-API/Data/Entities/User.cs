using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace goglobe_API.Data.Entities
{
    [Table("Users")]
    public class User: IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public string Surname { get; set; }
    }
}
