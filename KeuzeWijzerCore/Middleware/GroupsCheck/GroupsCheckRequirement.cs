using Microsoft.AspNetCore.Authorization;

namespace KeuzeWijzerCore.Middleware.GroupsCheck
{
    public class GroupsCheckRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> GroupIds { get; set; }

        public GroupsCheckRequirement(IEnumerable<string> groupIds)
        {
            GroupIds = groupIds;
        }
    }
}
