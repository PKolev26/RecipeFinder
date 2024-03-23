using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeFinder.Infrastructure.Constants.CommentDataConstants;
using static RecipeFinder.Infrastructure.Constants.ErrorsConstants;

namespace RecipeFinder.Core.Models.CommentModels
{
    public class CommentAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(CommentDescriptionMaxLength, MinimumLength = CommentDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;

        [Display(Name = "Author")]
        public string AuthorName { get; set; } = null!;

        [Display(Name = "Posted Date")]
        public string PostedOn { get; set; } = null!;

        public int RecipeId { get; set; }
    }
}
