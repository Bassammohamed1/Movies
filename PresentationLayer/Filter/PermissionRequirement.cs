using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Filter
{
    internal class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
