using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
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

        public CommentService(IRepository repository)
        {
            this.repository = repository;
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

        public async Task DeleteAsync(int commentId)
        {
            await repository.DeleteAsync<Comment>(commentId);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
               .AnyAsync(r => r.Id == id);
        }
        public async Task<CommentsInfoViewModel> CommentInformationByIdAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(r => r.Id == id)
                .Select(r => new CommentsInfoViewModel()
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    AuthorFirstName = r.Author.FirstName,
                    AuthorLastName = r.Author.LastName,
                    AuthorProfilePicture = r.Author.ProfilePicture,
                    PostedOn = r.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    RecipeId = r.RecipeId,
                    AuthorId = r.AuthorId
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<CommentsInfoViewModel>> AllCommentsAsync()
        {
            return await repository.AllReadOnly<Comment>()
                .OrderByDescending(r => r.PostedOn)
                .Select(r => new CommentsInfoViewModel()
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    AuthorFirstName = r.Author.FirstName,
                    AuthorLastName = r.Author.LastName,
                    AuthorProfilePicture = r.Author.ProfilePicture,
                    PostedOn = r.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    RecipeId = r.RecipeId,
                    RecipeName = r.Recipe.Name,
                    AuthorId = r.AuthorId
                })
                .ToListAsync();
        }
    }
}
