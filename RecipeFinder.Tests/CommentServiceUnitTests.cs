using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder.Tests
{
    public class CommentServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private ICommentService commentService;

        private ApplicationUser User1;

        private Recipe Recipe1;

        private Ingredient Ingredient1;

        private Comment Comment1;
        private Comment Comment2;

        [SetUp]
        public async Task SetUp()
        {
            User1 = new ApplicationUser
            {
                Id = "ba5ef817-fc4c-4c34-bf61-b1f495b010fd",
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                NormalizedUserName = "USER@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            Recipe1 = new Recipe
            {
                Id = 1,
                Name = "Recipe1",
                Instructions = "Instructions",
                CategoryId = 1,
                CookId = User1.Id,
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Ingredient1 = new Ingredient
            {
                Id = 1,
                Name = "Ingredient1",
                RecipeId = 1,
                Quantity = 1,
                Unit = "kg"
            };

            Comment1 = new Comment
            {
                Id = 1,
                Title = "Title",
                Description = "Comment1",
                RecipeId = 1,
                PostedOn = DateTime.Now,
                AuthorId = User1.Id
            };

            Comment2 = new Comment
            {
                Id = 2,
                Title = "Title",
                Description = "Comment2",
                RecipeId = 1,
                PostedOn = DateTime.Now,
                AuthorId = User1.Id
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
                .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(User1);

            await dbContext.AddAsync(Recipe1);

            await dbContext.AddAsync(Ingredient1);

            await dbContext.AddAsync(Comment1);
            await dbContext.AddAsync(Comment2);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            commentService = new CommentService(repository);
        }

        [TearDown]
        public async Task TearDown()
        {
            dbContext.Database.EnsureDeleted();
            await dbContext.DisposeAsync();
        }

        [Test]
        public async Task AddAsyncShouldAddCommentToDatabase()
        {
            // Arrange
            var commentAddViewModel = new CommentAddViewModel
            {
                Id = 3,
                Title = "Test Title",
                Description = "Test Description",
                AuthorId = User1.Id,
                PostedOn = DateTime.Now.ToString(RecipeDataConstants.DateAndTimeFormat),
                RecipeId = 1
            };

            // Act
            await commentService.AddAsync(commentAddViewModel, User1, 1);

            var comment = repository.AllReadOnly<Comment>().First(c => c.Id == 3);

            // Assert
            Assert.AreEqual(3, comment.Id);
            Assert.AreEqual("Test Title", comment.Title);
            Assert.AreEqual("Test Description", comment.Description);
            Assert.AreEqual(User1.Id, comment.AuthorId);
            Assert.AreEqual(1, comment.RecipeId);
        }

        [Test]
        public async Task DeleteAsyncShouldDeleteCommentFromDatabase()
        {
            // Arrange
            var comment = Comment1;

            // Act
            await commentService.DeleteAsync(comment.Id);

            var result = repository.AllReadOnly<Comment>().Where(c => c.Id == comment.Id);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task ExistsAsyncShouldReturnTrueIfCommentExists()
        {
            // Arrange
            var comment = Comment1;

            // Act
            var result = await commentService.ExistsAsync(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsyncShouldReturnFalseIfCommentDoesNotExist()
        {
            // Act
            var result = await commentService.ExistsAsync(3);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CommentInformationByIdAsyncShouldReturnCorrectComment()
        {
            // Arrange
            var comment = Comment1;

            // Act
            var result = await commentService.CommentInformationByIdAsync(1);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Title", result.Title);
            Assert.AreEqual("Comment1", result.Description);
            Assert.AreEqual(User1.FirstName, result.AuthorFirstName);
            Assert.AreEqual(User1.LastName, result.AuthorLastName);
            Assert.AreEqual(User1.ProfilePicture, result.AuthorProfilePicture);
            Assert.AreEqual(DateTime.Now.ToString(RecipeDataConstants.DateAndTimeFormat), result.PostedOn);
            Assert.AreEqual(1, result.RecipeId);
            Assert.AreEqual(User1.Id, result.AuthorId);
        }

        [Test]
        public async Task AllCommentsAsyncShouldReturnAllComments()
        {
            // Act
            var result = await commentService.AllCommentsAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result);
        }
    }
}
