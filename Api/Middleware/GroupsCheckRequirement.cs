using Microsoft.AspNetCore.Authorization;

namespace KeuzeWijzerApi.Middleware
{
    public class GroupsCheckRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> GroupIds { get; set; }

        public GroupsCheckRequirement(IEnumerable<string> groupIds)
        {
            this.GroupIds = groupIds;
        }
    }
}
