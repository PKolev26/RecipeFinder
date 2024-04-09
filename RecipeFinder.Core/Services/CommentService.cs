using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentService(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this._userManager = userManager;
        }

        public async Task AddAsync(CommentAddViewModel model, ApplicationUser authorId, int recipeId)
        {
            Comment newComment = new Comment
            {
                Title = model.Title,
                Description = model.Description,
                AuthorId = authorId.Id,
                PostedOn = DateTime.Now,
                RecipeId = recipeId
            };

            await repository.AddAsync(newComment);
            await repository.SaveChangesAsync();
        }
    }
}
