using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RecipeFinder.Infrastructure.Constants.IngredientDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Ingredient
    {
        [Key]
        [Comment("The Ingredient Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(IngredientNameMaxLength)]
        [Comment("The Ingredient Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(IngredientQuantityMinLength, IngredientQuantityMaxLength)]
        [Comment("The Ingredient Quantity")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [MaxLength(IngredientUnitMaxLength)]
        [Comment("The unit in which the ingredient is measured")]
        public string Unit { get; set; } = null!;

        [Required]
        [Comment("Recipe Identifier")]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [Comment("Recipe")]
        public Recipe Recipe { get; set; } = null!;


    }
}