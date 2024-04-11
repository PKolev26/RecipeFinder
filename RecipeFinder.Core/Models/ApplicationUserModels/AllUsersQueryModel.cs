using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.ApplicationUserModels
{
    public class AllUsersQueryModel
    {
        [Display(Name = "User Id")]
        public string Id { get; init; } = null!;

        [Display(Name = "First name")]
        public string FirstName { get; init; } = null!;

        [Display(Name = "Last name")]
        public string LastName { get; init; } = null!;

        [Display(Name = "Sorting")]
        public UserSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalUsersCount { get; set; }

        public IEnumerable<AllUsersSerivceModel> Users { get; set; } = new List<AllUsersSerivceModel>();
        public int UsersPerPage { get; set; } = 10;
    }
}
