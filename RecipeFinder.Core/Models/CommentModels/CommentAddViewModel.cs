using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage =RequiredErrorMessage)]
        [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(CommentDescriptionMaxLength, MinimumLength = CommentDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;

        public DateTime PostedOn { get; set; }

        public int RecipeId { get; set; }
    }
}
