using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Comment
{
    public interface ICommentService
    {
        Task AddAsync(CommentAddViewModel model, ApplicationUser authorId, int recipeId);
    }
}
