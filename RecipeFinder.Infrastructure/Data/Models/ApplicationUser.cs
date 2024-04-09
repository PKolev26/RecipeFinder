using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RecipeFinder.Infrastructure.Constants.ApplicationUserDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public string ProfilePicture { get; set; } = "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg";

    }
}
