using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RecipeFinder.Infrastructure.Constants.DifficultyDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Difficulty
    {

        [Key]
        [Comment("This Difficulty Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DifficultyNameMaxLength)]
        [Comment("The Difficulty Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DifficultyDescriptionMaxLength)]
        [Comment("The Difficulty Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(DifficultySkillLevelMin,DifficultySkillLevelMax)]
        [Comment("The recommended skill level that the cook should have")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SkillLevel { get; set; }

        [Required]
        [MaxLength(DifficultyIngredientComplexityMaxLength)]
        [Comment("The Ingredient Complexity")]
        public string IngredientComplexity { get; set; } = null!;

        [Comment("All Recipes that are in this Difficulty")]
        public ICollection<Recipe> Recipes = new HashSet<Recipe>();
    }
}
