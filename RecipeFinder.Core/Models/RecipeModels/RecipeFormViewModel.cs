using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.RecipeDataConstants;
using static RecipeFinder.Infrastructure.Constants.ErrorsConstants;
using System.ComponentModel;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Core.Models.IngredientModels;

namespace RecipeFinder.Core.Models.RecipeModels
{
    public class RecipeFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Recipe name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RecipeInstructionsMaxLength, MinimumLength = RecipeInstructionsMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Recipe instruction")]
        public string Instructions { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe picture")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(RecipePreparetionTimeMinLength, RecipePreparetionTimeMaxLength, ErrorMessage = PrepTimeLengthErrorMessage)]
        [Display(Name = "Recipe preparation time")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Recipe difficulty")]
        public int DifficultyId { get; set; }
        public IEnumerable<DifficultyViewModel> Difficulties { get; set; } = new List<DifficultyViewModel>();

        public string CookId { get; set; } = null!;
    }
}
