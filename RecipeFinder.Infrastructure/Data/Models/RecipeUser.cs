using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class RecipeUser
    {
        [Required]
        [Comment("Recipe Identifier")]
        public int RecipeId { get; set; }

        [Comment("Recipe")]
        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; } = null!;

        [Required]
        [Comment("Maker Identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Maker")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
