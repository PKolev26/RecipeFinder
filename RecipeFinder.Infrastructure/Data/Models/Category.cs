using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RecipeFinder.Infrastructure.Constants.CategoryDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("This Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("The Category Name")]
        public string Name { get; set; } = null!;

        [Comment("All Recipes that are in this Category")]
        public ICollection<Recipe> Recipes = new HashSet<Recipe>();
    }
}