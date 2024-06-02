using Microsoft.AspNetCore.Authorization;

namespace KeuzeWijzerCore.Middleware.GroupsCheck
{
    public class GroupsCheckRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> GroupIds { get; set; }
        public bool MustIncludeAll { get; set; } = true;

        public GroupsCheckRequirement(IEnumerable<string> groupIds, bool mustIncludeAll = true)
        {
            GroupIds = groupIds;
            MustIncludeAll = mustIncludeAll;
        }
    }
}
