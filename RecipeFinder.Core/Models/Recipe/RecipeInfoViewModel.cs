using Microsoft.AspNetCore.Identity;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.Recipe
{
    public class RecipeInfoViewModel
    {

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

        [Display(Name = "Ingredients count")]
        public int IngredientCount { get; set; }

        [Display(Name = "Comments count")]
        public int CommentCount { get; set; }

        [Display(Name = "Made by")]
        public int MadeByCount { get; set; }
    }
}
