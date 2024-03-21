using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.CommentModels
{
    public class CommentDetailsViewModel
    {

        [Display( Name ="Comment Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Comment Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Comment Author")]
        public string AuthorName { get; set; } = null!;

        [Display(Name = "Comment Posted Date")]
        public string PostedOn { get; set; } = null!;
    }
}
