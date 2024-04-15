using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Tests
{
    [TestFixture]
    public class ApplicationUserServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private IApplicationUserService applicationUserService;
        private IRecipeService recipeService;
        private UserManager<ApplicationUser> userManager;

        private ApplicationUser User1;
        private ApplicationUser User2;
        private ApplicationUser User3;

        private Recipe Recipe1;

        private Ingredient Ingredient1;

        private Comment Comment1;

        private RecipeUser RecipeUser1;

        private ApplicationUser Admin1;

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

            User2 = new ApplicationUser
            {
                Id = "d49eecf0-fc59-4922-8618-b527b767468b",
                UserName = "user2@gmail.com",
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                NormalizedUserName = "USER2@GMAIL.COM",
                FirstName = "User",
                LastName = "User2"
            };

            User3 = new ApplicationUser
            {
                Id = "8b1348e7-1596-40f1-98ee-06a3ccf20feb",
                UserName = "user3@gmail.com",
                Email = "user3@gmail.com",
                NormalizedEmail = "USER3@GMAIL.COM",
                NormalizedUserName = "USER3@GMAIL.COM",
                FirstName = "User3",
                LastName = "User3"
            };

            Admin1 = new ApplicationUser
            {
                Id = "180e0cf6-0f20-46d6-9020-74da9738296f",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Admin"
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
                PostedOn = DateTime.Now
            };

            RecipeUser1 = new RecipeUser
            {
                RecipeId = 1,
                UserId = User2.Id
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
                .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(User1);
            await dbContext.AddAsync(User2);
            await dbContext.AddAsync(User3);
            await dbContext.AddAsync(Admin1);

            await dbContext.AddAsync(Recipe1);

            await dbContext.AddAsync(Ingredient1);

            await dbContext.AddAsync(Comment1);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            applicationUserService = new ApplicationUserService(repository, userManager);
            recipeService = new RecipeService(repository, userManager);
        }

        [TearDown]
        public async Task TearDown()
        {
            await dbContext.Database.EnsureDeletedAsync();
        }

        [Test]
        public async Task AllUsers_FilterByFirstName_ShouldReturnCorrectResult()
        {
            // Arrange
            var firstname = User1.FirstName;

            // Act
            var result = await applicationUserService.AllUsersAsync(firstName: firstname);

            // Assert
            Assert.AreEqual(2, result.TotalUsersCount);
        }

        [Test]
        public async Task AllUsers_FilterById_ShouldReturnCorrectResult()
        {
            // Arrange
            var id = User1.Id;

            // Act
            var result = await applicationUserService.AllUsersAsync(id);

            // Assert
            Assert.AreEqual(1, result.TotalUsersCount);
        }

        [Test]
        public async Task AllUsers_FilterByLastName_ShouldReturnCorrectResult()
        {
            // Arrange
            var lastName = User1.LastName;

            // Act
            var result = await applicationUserService.AllUsersAsync(lastName: lastName);

            // Assert
            Assert.AreEqual(1, result.TotalUsersCount);
        }

        [Test]
        public async Task AllUsers_FilterBySortingEmailAscending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyEmailAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.EmailAscending, 1, 4);

            var users = new List<string>()
            {
                sortingbyEmailAscending.Users.First().Email,
                sortingbyEmailAscending.Users.Skip(1).First().Email,
                sortingbyEmailAscending.Users.Skip(2).First().Email,
                sortingbyEmailAscending.Users.Last().Email
            };

            // Assert
            Assert.IsNotNull(sortingbyEmailAscending.Users);
            Assert.AreEqual(4, sortingbyEmailAscending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "admin@gmail.com", "user@gmail.com", "user2@gmail.com", "user3@gmail.com" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingEmailDescending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyEmailDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.EmailDescending, 1, 4);

            var users = new List<string>()
            {
                sortingbyEmailDescending.Users.First().Email,
                sortingbyEmailDescending.Users.Skip(1).First().Email,
                sortingbyEmailDescending.Users.Skip(2).First().Email,
                sortingbyEmailDescending.Users.Last().Email

            };

            // Assert
            Assert.IsNotNull(sortingbyEmailDescending.Users);
            Assert.AreEqual(4, sortingbyEmailDescending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "user3@gmail.com" , "user2@gmail.com", "user@gmail.com", "admin@gmail.com" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingFirstNameAscending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyFirstNameAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.FirstNameAscending, 1, 4);

            var users = new List<string>()
            {
                sortingbyFirstNameAscending.Users.First().FirstName,
                sortingbyFirstNameAscending.Users.Skip(1).First().FirstName,
                sortingbyFirstNameAscending.Users.Skip(2).First().FirstName,
                sortingbyFirstNameAscending.Users.Last().FirstName
            };

            // Assert
            Assert.IsNotNull(sortingbyFirstNameAscending.Users);
            Assert.AreEqual(4, sortingbyFirstNameAscending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "Admin", "User", "User", "User3" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingFirstNameDescending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyFirstNameDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.FirstNameDescending, 1, 4);

            var users = new List<string>()
            {
                sortingbyFirstNameDescending.Users.First().FirstName,
                sortingbyFirstNameDescending.Users.Skip(1).First().FirstName,
                sortingbyFirstNameDescending.Users.Skip(2).First().FirstName,
                sortingbyFirstNameDescending.Users.Last().FirstName
            };

            // Assert
            Assert.IsNotNull(sortingbyFirstNameDescending.Users);
            Assert.AreEqual(4, sortingbyFirstNameDescending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "User3", "User", "User", "Admin" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingLastNameAscending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyLastNameAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.LastNameAscending, 1, 4);

            var users = new List<string>()
            {
                sortingbyLastNameAscending.Users.First().LastName,
                sortingbyLastNameAscending.Users.Skip(1).First().LastName,
                sortingbyLastNameAscending.Users.Skip(2).First().LastName,
                sortingbyLastNameAscending.Users.Last().LastName
            };

            // Assert
            Assert.IsNotNull(sortingbyLastNameAscending.Users);
            Assert.AreEqual(4, sortingbyLastNameAscending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "Admin", "User", "User2", "User3" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingLastNameDescending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyLastNameDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.LastNameDescending, 1, 4);

            var users = new List<string>()
            {
                sortingbyLastNameDescending.Users.First().LastName,
                sortingbyLastNameDescending.Users.Skip(1).First().LastName,
                sortingbyLastNameDescending.Users.Skip(2).First().LastName,
                sortingbyLastNameDescending.Users.Last().LastName
            };

            // Assert
            Assert.IsNotNull(sortingbyLastNameDescending.Users);
            Assert.AreEqual(4, sortingbyLastNameDescending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "User3", "User2", "User", "Admin" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingIdAscending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyIdAscending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.IdAscending, 1, 4);

            var users = new List<string>()
            {
                sortingbyIdAscending.Users.First().Id,
                sortingbyIdAscending.Users.Skip(1).First().Id,
                sortingbyIdAscending.Users.Skip(2).First().Id,
                sortingbyIdAscending.Users.Last().Id
            };

            // Assert
            Assert.IsNotNull(sortingbyIdAscending.Users);
            Assert.AreEqual(4, sortingbyIdAscending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "180e0cf6-0f20-46d6-9020-74da9738296f", "8b1348e7-1596-40f1-98ee-06a3ccf20feb", "ba5ef817-fc4c-4c34-bf61-b1f495b010fd", "d49eecf0-fc59-4922-8618-b527b767468b" }, users);
        }

        [Test]
        public async Task AllUsers_FilterBySortingIdDescending_ShouldReturnCorrectResult()
        {
            // Act
            var sortingbyIdDescending = await applicationUserService.AllUsersAsync(null, null, null, UserSorting.IdDescending, 1, 4);

            var users = new List<string>()
            {
                sortingbyIdDescending.Users.First().Id,
                sortingbyIdDescending.Users.Skip(1).First().Id,
                sortingbyIdDescending.Users.Skip(2).First().Id,
                sortingbyIdDescending.Users.Last().Id
            };

            // Assert
            Assert.IsNotNull(sortingbyIdDescending.Users);
            Assert.AreEqual(4, sortingbyIdDescending.TotalUsersCount);
            Assert.AreEqual(new List<string>() { "d49eecf0-fc59-4922-8618-b527b767468b", "ba5ef817-fc4c-4c34-bf61-b1f495b010fd", "8b1348e7-1596-40f1-98ee-06a3ccf20feb", "180e0cf6-0f20-46d6-9020-74da9738296f" }, users);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteUser()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            await applicationUserService.DeleteAsync(userId);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Assert
            Assert.IsNull(user);
            Assert.AreEqual(3, dbContext.Users.Count());
            Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteUserAndRecipes()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            await applicationUserService.DeleteAsync(userId);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Assert
            Assert.IsNull(user);
            Assert.AreEqual(3, dbContext.Users.Count());
            Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
            Assert.IsTrue(await recipeService.ExistsAsync(1) == false);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteUserAndRecipesAndComments()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            await applicationUserService.DeleteAsync(userId);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Assert
            Assert.IsNull(user);
            Assert.AreEqual(3, dbContext.Users.Count());
            Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
            Assert.IsTrue(await recipeService.ExistsAsync(1) == false);
            Assert.IsTrue(await dbContext.Comments.FirstOrDefaultAsync(c => c.Id == 1) == null);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteUserAndRecipesAndIngredients()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            await applicationUserService.DeleteAsync(userId);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Assert
            Assert.IsNull(user);
            Assert.AreEqual(3, dbContext.Users.Count());
            Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
            Assert.IsTrue(await recipeService.ExistsAsync(1) == false);
            Assert.IsTrue(await dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == 1) == null);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteUserAndRecipesAndRecipeUser()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            await applicationUserService.DeleteAsync(userId);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Assert
            Assert.IsNull(user);
            Assert.AreEqual(3, dbContext.Users.Count());
            Assert.IsTrue(await applicationUserService.ExistsAsync(userId) == false);
            Assert.IsTrue(await recipeService.ExistsAsync(1) == false);
            Assert.IsTrue(await dbContext.RecipesUsers.FirstOrDefaultAsync(ru => ru.RecipeId == 1) == null);
        }

        [Test]
        public async Task ExistsAsync_UserExists_ShouldReturnTrue()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            var result = await applicationUserService.ExistsAsync(userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_UserDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var userId = "5";

            // Act
            var result = await applicationUserService.ExistsAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task UserDetailsAsync_ShouldReturnCorrectUserDetails()
        {
            // Arrange
            var userId = User1.Id;

            // Act
            var result = await applicationUserService.UserDetailsAsync(userId);

            // Assert
            Assert.AreEqual(User1.Id, result.Id);
            Assert.AreEqual(User1.Email, result.Email);
            Assert.AreEqual(User1.UserName, result.UserName);
            Assert.AreEqual(User1.FirstName, result.FirstName);
            Assert.AreEqual(User1.LastName, result.LastName);
        }
    }
}
