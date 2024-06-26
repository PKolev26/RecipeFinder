﻿using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeFinder.Core.Models.RecipeModels
{
    public class RecipeDetailsServiceModel : IRecipeModel
    { 
        [Display(Name = "Recipe Identifier")]
        public int Id { get; set; }

        [Display(Name = "Recipe")]
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Preparation time")]
        public int PreparationTime { get; set; }

        [Display(Name = "Instructions")]
        public string Instructions { get; set; } = null!;

        [Display(Name = "Posted on")]
        public string PostedOn { get; set; } = null!;

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Difficulty")]
        public string DifficultyName { get; set; } = null!;

        [Display(Name = "Recipe's cook id")]
        public string CookId = null!;

        [Display(Name = "Cooked by first name")]
        public string CookFirstName { get; set; } = null!;

        [Display(Name = "Cooked by last name")]
        public string CookLastName { get; set; } = null!;

        [Display(Name = "Recipe's ingredients")]
        public ICollection<Ingredient> Ingredients { get; set;} = new List<Ingredient>();

        [Display(Name = "Recipe's comments")]
        public ICollection<CommentsInfoViewModel> Comments { get; set; } = new List<CommentsInfoViewModel>();

        [Display(Name = "Made by")]
        public int MadeByCount { get; set; }
        public CommentAddViewModel AddComment { get; set; } = new CommentAddViewModel();

        public RecipeUser RecipeUser = new RecipeUser();
    }
}
