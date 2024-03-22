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
    public class RecipeAddViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RecipeInstructionsMaxLength, MinimumLength = RecipeInstructionsMinLength, ErrorMessage = LengthErrorMessage)]
        public string Instructions { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(RecipePreparetionTimeMinLength, RecipePreparetionTimeMaxLength, ErrorMessage = LengthErrorMessage)]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int DifficultyId { get; set; }
        public IEnumerable<DifficultyViewModel> Difficulties { get; set; } = new List<DifficultyViewModel>();
    }
}
