using RecipeFinder.Core.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.ApplicationUserModels
{
    public class UserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }

        public IEnumerable<AllUsersSerivceModel> Users { get; set; } = new List<AllUsersSerivceModel>();
    }
}
