using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;

namespace KeuzeWijzerApi.Middleware
{
    public class GroupsCheckHandler : AuthorizationHandler<GroupsCheckRequirement>
    {
        private readonly GraphServiceClient _graphServiceClient;

        public GroupsCheckHandler(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupsCheckRequirement requirement)
        {
            var result = await _graphServiceClient.Me.CheckMemberGroups(requirement.GroupIds).Request().PostAsync();

            // If the result contains all required group id's then the requirement has been met
            if (result.All(groupId => requirement.GroupIds.Contains(groupId)))
            {
                context.Succeed(requirement);
            }
        }
    }
}
