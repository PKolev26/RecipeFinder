namespace RecipeFinder.Core.Models.AdminModels
{
    public class AdminLatest10ServiceModel
    {
        public string CookFirstName { get; set; } = null!;

        public string CookLastName { get; set; } = null!;

        public string Recipe { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string DifficultyName { get; set; } = null!;

        public string PostedOn { get; set; } = null!;

        public int CommentsCount { get; set; }

        public bool IsFinished { get; set; }
    }
}
