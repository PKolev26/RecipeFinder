namespace RecipeFinder.Core.Models.ApplicationUserModels
{
    public class UserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }

        public IEnumerable<AllUsersSerivceModel> Users { get; set; } = new List<AllUsersSerivceModel>();
    }
}
