using Microsoft.AspNetCore.Identity;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.Recipe
{
    public class AllRecipeViewModel
    {
        public AllRecipeViewModel(string name, string imageUrl, int preparationTime, DateTime postedOn, string category, string difficulty, int ingredientCount, int commentCount, int madeByCount)
        {
            Name = name;
            ImageUrl = imageUrl;
            PreparationTime = preparationTime;
            PostedOn = postedOn;
            Category = new Category { Name = category };
            Difficulty = new Difficulty { Name = difficulty };
            IngredientCount = ingredientCount;
            CommentCount = commentCount;
            MadeByCount = madeByCount;
        }

        [Display(Name = "Recipe")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Preparation time")]
        public int PreparationTime { get; set; }

        [Display(Name = "Posted on")]
        public DateTime PostedOn { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Difficulty")]
        public Difficulty Difficulty { get; set; }

        [Display(Name = "Cooked by")]
        public IdentityUser Cook { get; set; }

        [Display(Name = "Ingredients count")]
        public int IngredientCount { get; set; }

        [Display(Name = "Comments count")]
        public int CommentCount { get; set; }

        [Display(Name = "Made by")]
        public int MadeByCount { get; set; }
    }
}
