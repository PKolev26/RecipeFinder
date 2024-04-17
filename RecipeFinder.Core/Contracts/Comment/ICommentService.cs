using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Contracts.Comment
{
    public interface ICommentService
    {
        Task AddAsync(CommentAddViewModel model, ApplicationUser authorId, int recipeId);

        Task DeleteAsync(int commentId);

        Task<bool> ExistsAsync(int id);

        Task<CommentsInfoViewModel> CommentInformationByIdAsync(int id);

        Task<IEnumerable<CommentsInfoViewModel>> AllCommentsAsync();
    }
}
