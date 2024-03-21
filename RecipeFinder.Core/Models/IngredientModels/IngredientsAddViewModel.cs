using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.IngredientDataConstants;
using static RecipeFinder.Infrastructure.Constants.ErrorsConstants;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecipeFinder.Core.Models.IngredientModels
{
    public class IngredientsAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(IngredientQuantityMinLength, IngredientQuantityMaxLength, ErrorMessage = LengthErrorMessage)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(IngredientUnitMaxLength, MinimumLength = IngredientUnitMinLength, ErrorMessage = LengthErrorMessage)]
        public string Unit { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int RecipeId { get; set; }

    }
}
