using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository repository)
        {
            this.repository = repository;
        }

        // AddAsync method is used to add a comment to a recipe. It takes a CommentAddViewModel, ApplicationUser, and recipeId as parameters. It creates a new Comment object and adds it to the database.

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

        // DeleteAsync method is used to delete a comment from the database. It takes a commentId as a parameter and deletes the comment.

        public async Task DeleteAsync(int commentId)
        {
            await repository.DeleteAsync<Comment>(commentId);
            await repository.SaveChangesAsync();
        }

        // ExistsAsync method is used to check if a comment exists in the database. It takes a commentId as a parameter and returns a boolean.

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
               .AnyAsync(r => r.Id == id);
        }

        // CommentInformationByIdAsync method is used to get information about a comment by its id. It takes a commentId as a parameter and returns a CommentsInfoViewModel.

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
                    RecipeName = r.Recipe.Name,
                    AuthorId = r.AuthorId
                })
                .FirstAsync();
        }

        // AllCommentsAsync method is used to get all comments in the database. It returns an IEnumerable of CommentsInfoViewModel.

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
