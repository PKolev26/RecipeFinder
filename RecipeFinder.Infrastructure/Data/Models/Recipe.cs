using Microsoft.AspNetCore.Identity;
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
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(RecipeInstructionsMaxLength)]
        [Comment("The Recipe Instructions")]
        public string Instructions { get; set; } = null!;

        [Required]
        [Comment("The Recipe Cover Image")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("The Recipe Preparation Time")]
        public int PreparationTime { get; set; }

        [Required]
        [Comment("Date of post")]
        public DateTime PostedOn { get; set; }

        [Comment("The Recipe Category Id")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("The Recipe Category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("The Recipe Difficulty Id")]
        [Required]
        public int DifficultyId { get; set; }

        [Comment("The Recipe Difficulty")]
        [ForeignKey(nameof(DifficultyId))]
        public Difficulty Difficulty { get; set; } = null!;

        [Required]
        [Comment("The Cook Identifier")]
        public string CookId { get; set; } = string.Empty;

        [Comment("The Cook")]
        [ForeignKey(nameof(CookId))]
        public IdentityUser Cook { get; set; } = null!;

        [Required]
        [Comment("A list of all ingredients")]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [Comment("A list of all comments")]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [Comment("Recipe Users")]
        public ICollection<RecipeUser> RecipesUsers { get; set; } = new List<RecipeUser>();
    }
}
