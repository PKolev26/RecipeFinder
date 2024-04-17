using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.ApplicationUserModels
{
    public class UsersDetailsServiceModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; } = null!;

        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }
}
