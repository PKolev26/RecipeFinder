using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.CategoryModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Number of Recipes")]
        public int RecipeCount { get; set; }
    }
}
