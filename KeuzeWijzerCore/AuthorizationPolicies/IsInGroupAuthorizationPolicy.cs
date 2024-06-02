using KeuzeWijzerCore.Middleware.GroupsCheck;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KeuzeWijzerCore.AuthorizationPolicies
{
    public class IsInGroupAuthorizationPolicy
    {
        public const string IsInAdministratorGroupPolicyName = "IsInAdminGroup";
        public const string IsInStudentGroupPolicyName = "IsInStudentGroup";
        public const string IsInStudentSupervisorGroupPolicyName = "IsInStudentSupervisorGroup";
        public const string IsInStudentOrStudentSupervisorGroupPolicyName = "IsInStudentOrStudentSupervisorGroup";

        private readonly Groups _options = new();

        public IsInGroupAuthorizationPolicy(IConfigurationSection configurationSection)
        {
            configurationSection.Bind(_options);

            if (_options == null)
            {
                throw new Exception($"{nameof(_options)} was not bound successfully");
            }
        }

        public void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(IsInAdministratorGroupPolicyName, policy => policy.Requirements.Add(new GroupsCheckRequirement([_options.AdministratorGroupId!])));
            options.AddPolicy(IsInStudentGroupPolicyName, policy => policy.Requirements.Add(new GroupsCheckRequirement([_options.StudentGroupId!])));
            options.AddPolicy(IsInStudentSupervisorGroupPolicyName, policy => policy.Requirements.Add(new GroupsCheckRequirement([_options.StudentSupervisorGroupId!])));
            options.AddPolicy(IsInStudentOrStudentSupervisorGroupPolicyName, policy => policy.Requirements.Add(new GroupsCheckRequirement([_options.StudentGroupId!, _options.StudentSupervisorGroupId!], false)));
        }

        private class Groups
        {
            public string? AdministratorGroupId { get; set; }
            public string? StudentGroupId { get; set; }
            public string? StudentSupervisorGroupId { get; set; }
        }
    }

    #region Attributes          |
    // Attributes to make assigning these Authorize policies easier
    // Might be a bit overkill for out use but i think its funny :P

    public class AuthorizeIsInAdministratorGroupAttribute : AuthorizeAttribute
    {
        public AuthorizeIsInAdministratorGroupAttribute()
        {
            Policy = IsInGroupAuthorizationPolicy.IsInAdministratorGroupPolicyName;
        }
    }

    public class AuthorizeIsInStudentGroupAttribute : AuthorizeAttribute
    {
        public AuthorizeIsInStudentGroupAttribute()
        {
            Policy = IsInGroupAuthorizationPolicy.IsInStudentGroupPolicyName;
        }
    }

    public class AuthorizeIsInStudentSupervisorGroupAttribute : AuthorizeAttribute
    {
        public AuthorizeIsInStudentSupervisorGroupAttribute()
        {
            Policy = IsInGroupAuthorizationPolicy.IsInStudentSupervisorGroupPolicyName;
        }
    }

    public class AuthorizeIsInStudentOrStudentSupervisorGroupAttribute : AuthorizeAttribute
    {
        public AuthorizeIsInStudentOrStudentSupervisorGroupAttribute()
        {
            Policy = IsInGroupAuthorizationPolicy.IsInStudentOrStudentSupervisorGroupPolicyName;
        }
    }
    #endregion
}
