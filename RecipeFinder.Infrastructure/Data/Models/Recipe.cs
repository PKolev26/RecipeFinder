using Microsoft.EntityFrameworkCore;
using RecipeFinder.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.RecipeDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Recipe
    {
        [Key]
        [Comment("The Recipe Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(RecipeNameMaxLength)]
        [Comment("The Recipe Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(RecipeInstructionsMaxLength)]
        [Comment("The Recipe Instructions")]
        public string Instructions { get; set; } = string.Empty;

        [Required]
        [Comment("The Recipe Cover Image")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("The Recipe Preparation Time")]
        public int PreparationTime { get; set; }

        [Comment("The Recipe Category Id")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("The Recipe Category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
    }
}
