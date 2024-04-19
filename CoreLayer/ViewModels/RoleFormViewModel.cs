using System.ComponentModel.DataAnnotations;

namespace CoreLayer.ViewModels
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
