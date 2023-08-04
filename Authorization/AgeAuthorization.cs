using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LoginSimulator.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimalAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimalAge requirement)
    {
        var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if(birthDateClaim is null)
            return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthDateClaim.Value);

        if(birthDate.AddYears(18) <= DateTime.Now)
            context.Succeed(requirement);
        
        return Task.CompletedTask;
    }
}
