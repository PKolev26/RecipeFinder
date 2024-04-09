using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.ErrorsConstants;
using static RecipeFinder.Infrastructure.Constants.RecipeDataConstants;

namespace RecipeFinder.Core.Models.RecipeModels
{
    public class RecipeServiceModel : IRecipeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe picture")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(RecipePreparetionTimeMinLength, RecipePreparetionTimeMaxLength, ErrorMessage = PrepTimeLengthErrorMessage)]
        [Display(Name = "Recipe preparation time")]
        public int PreparationTime { get; set; }

        [Display(Name = "Posted on")]
        public string PostedOn { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public string CategoryName { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe difficulty")]
        public int DifficultyId { get; set; }
        public IEnumerable<DifficultyViewModel> Difficulties { get; set; } = new List<DifficultyViewModel>();

        public string DifficultyName { get; set; } = null!;

        [Display(Name = "Cooked username")]
        public string CookUsername { get; set; } = null!;

        [Display(Name = "Cooked by first name")]
        public string CookFirstName { get; set; } = null!;

        [Display(Name = "Cooked by last name")]
        public string CookLastName { get; set; } = null!;

        [Display(Name = "Ingredients count")]
        public int IngredientCount { get; set; }

        [Display(Name = "Comments count")]
        public int CommentCount { get; set; }

        [Display(Name = "Made by")]
        public int MadeByCount { get; set; }

        [Display(Name = "Users that made this recipe")]
        public RecipeUser RecipeUser = new RecipeUser();
    }
}
