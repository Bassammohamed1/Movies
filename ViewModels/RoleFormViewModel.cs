using System.ComponentModel.DataAnnotations;

namespace Movies.ViewModels
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
