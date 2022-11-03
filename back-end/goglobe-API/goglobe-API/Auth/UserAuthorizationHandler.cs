using goglobe_API.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace goglobe_API.Auth
{
    public class UserAuthorizationHandler : AuthorizationHandler<SameUserRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement,
            IUserOwnedResource resource)
        {
            if (context.User.IsInRole(UserRoles.Admin) || context.User.FindFirst(CustomClaims.UserId).Value == resource.ClientId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public record SameUserRequirement : IAuthorizationRequirement;
}
