namespace Movies.IdentityViewModels
{
    public class RolesPermissionsViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<PermissionsViewModel> Permissions { get; set; }
    }
}
