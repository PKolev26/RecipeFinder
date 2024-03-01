﻿using Microsoft.AspNetCore.Identity;
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

        [Required]
        [Comment("The Cook Identifier")]
        public string CookId { get; set; } = string.Empty;

        [Comment("The Cook")]
        [ForeignKey(nameof(CookId))]
        public IdentityUser Cook { get; set; } = null!;

        [Required]
        [Comment("A list of all ingredients")]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [Comment("Recipe Cooks")]
        public IList<RecipeMaker> RecipesMakers { get; set; } = new List<RecipeMaker>();
    }
}
