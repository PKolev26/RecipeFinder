using RecipeFinder.Core.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.CategoryModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Number of Recipes")]
        public int RecipeCount { get; set; }
    }
}
