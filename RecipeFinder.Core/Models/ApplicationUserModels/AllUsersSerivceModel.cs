using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.ApplicationUserModels
{
    public class AllUsersSerivceModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }
}
