using RecipeFinder.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.RecipeModels
{
    public class AllRecipesQueryModel
    {
        public string Category { get; init; } = null!;

        public string Difficulty { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string Search { get; init; } = null!;

        public RecipeSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalRecipesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> Difficulties { get; set; } = null!;

        public IEnumerable<RecipeServiceModel> Recipes { get; set; } = new List<RecipeServiceModel>();

        public int RecipesPerPage { get; set; } = 12;

    }
}
