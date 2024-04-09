using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.CommentDataConstants;

namespace RecipeFinder.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        [Comment("Comment Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentTitleMaxLength)]
        [Comment("Comment Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(CommentDescriptionMaxLength)]
        [Comment("Comment Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Comment Author Identifier")]
        public string AuthorId { get; set; } = string.Empty;

        [ForeignKey(nameof(AuthorId))]
        [Comment("Comment Author")]
        public ApplicationUser Author { get; set; } = null!;

        [Required]
        [Comment("Comment Posted Date")]
        public DateTime PostedOn { get; set; }

        [Required]
        [Comment("Recipe Identifier")]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [Comment("Recipe")]
        public Recipe Recipe { get; set; } = null!;

    }
}
