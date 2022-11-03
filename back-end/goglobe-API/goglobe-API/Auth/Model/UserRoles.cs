using System.Collections.Generic;

namespace goglobe_API.Auth.Model
{
    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Client = nameof(Client);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Client };
    }
}
