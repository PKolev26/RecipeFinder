using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class CommentsInfoViewModel
    {
        public int Id { get; set; }
        [Display( Name ="Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Author")]
        public string AuthorName { get; set; } = null!;

        [Display(Name = "Posted Date")]
        public string PostedOn { get; set; } = null!;
        public int RecipeId {  get; set; }
    }
}
