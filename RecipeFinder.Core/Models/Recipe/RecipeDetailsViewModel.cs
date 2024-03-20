using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.Recipe
{
    public class RecipeDetailsViewModel
    {
        [Display(Name = "Recipe Identifier")]
        public int Id { get; set; }

        [Display(Name = "Recipe")]
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Preparation time")]
        public int PreparationTime { get; set; }

        [Display(Name = "Posted on")]
        public string PostedOn { get; set; } = null!;

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Difficulty")]
        public string DifficultyName { get; set; } = null!;

        [Display(Name = "Cooked by")]
        public string Cook { get; set; } = null!;

        [Display(Name = "Recipe's ingredients")]
        public ICollection<Ingredient> Ingredients { get; set;} = new List<Ingredient>();

        [Display(Name = "Recipe's comments")]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [Display(Name = "Made by")]
        public int MadeByCount { get; set; }
    }
}
