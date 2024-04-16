using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;

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
            Assert.That(comment.Id, Is.EqualTo(3));
            Assert.That(comment.Title, Is.EqualTo("Test Title"));
            Assert.That(comment.Description, Is.EqualTo("Test Description"));
            Assert.That(comment.AuthorId, Is.EqualTo(User1.Id));
            Assert.That(comment.RecipeId, Is.EqualTo(1));
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
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("Title"));
            Assert.That(result.Description, Is.EqualTo("Comment1"));
            Assert.That(result.AuthorFirstName, Is.EqualTo(User1.FirstName));
            Assert.That(result.AuthorLastName, Is.EqualTo(User1.LastName));
            Assert.That(result.AuthorProfilePicture, Is.EqualTo(User1.ProfilePicture));
            Assert.That(result.PostedOn, Is.EqualTo(DateTime.Now.ToString(RecipeDataConstants.DateAndTimeFormat)));
            Assert.That(result.RecipeId, Is.EqualTo(1));
            Assert.That(result.AuthorId, Is.EqualTo(User1.Id));
        }

        [Test]
        public async Task AllCommentsAsyncShouldReturnAllComments()
        {
            // Act
            var result = await commentService.AllCommentsAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.IsNotNull(result);
        }
    }
}
