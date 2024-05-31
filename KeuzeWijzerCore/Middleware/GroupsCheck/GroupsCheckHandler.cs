using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KeuzeWijzerCore.Middleware.GroupsCheck
{
    public class GroupsCheckHandler : AuthorizationHandler<GroupsCheckRequirement>
    {
        private const string GroupsTypeName = "groups";

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupsCheckRequirement requirement)
        {
            var result = GetGroups(context.User);
            if (requirement.GroupIds.All(groupId => result.Contains(groupId)))
            {
                context.Succeed(requirement);
            }
        }

        private static IEnumerable<string> GetGroups(ClaimsPrincipal user)
        {
            return user.Claims.Where(x => x.Type == GroupsTypeName).Select(x => x.Value);
        }
    }
}
