namespace RecipeFinder.Core.Models.AdminModels
{
    public class AdminPanelServiceModel
    {
        public int TotalUsers { get; set; }

        public int TotalRecipes { get; set; }

        public int TotalComments { get; set; }

        public ICollection<AdminLatest10ServiceModel> Latest { get; set; } = new List<AdminLatest10ServiceModel>();
    }
}
