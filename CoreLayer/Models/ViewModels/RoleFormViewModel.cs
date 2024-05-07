using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models.ViewModels
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
