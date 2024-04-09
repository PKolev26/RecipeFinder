using Microsoft.AspNetCore.Identity;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class SeedData
    {
        // Users
        public ApplicationUser User1 { get; set; }
        public ApplicationUser User2 { get; set; }

        public ApplicationUser Admin { get; set; }

        // Categories
        public Category FirstCategory { get; set; }
        public Category SecondCategory { get; set; }
        public Category ThirdCategory { get; set; }

        // Difficulties
        public Difficulty Beginner { get; set; }
        public Difficulty Intermediate { get; set; }
        public Difficulty Advanced { get; set; }
        public Difficulty Expert { get; set; }
        public Difficulty MasterChef { get; set; }

        // Recipes
        public Recipe Moussaka {  get; set; }
        public Recipe Pancakes { get; set; }

        // Comment
        public Comment MoussakaComment { get; set; }

        // Ingredient
        public Ingredient MoussakaPotato { get; set; }
        public Ingredient MoussakaМeat { get; set; }

        public Ingredient PancakesFlour { get; set; }
        public Ingredient PancakesMilk { get; set; }
        public Ingredient PancakesEgg { get; set; }
        public Ingredient PancakesButter { get; set; }
        public Ingredient PancakesSugar { get; set; }
        public Ingredient PancakesBakingPowder { get; set; }
        public Ingredient PancakesSalt { get; set; }


        public SeedData()
        {
            SeedUsers();
            SeedDifficulties();
            SeedCategories();
            SeedRecipes();
            SeedIngredient();
            SeedComments();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            User1 = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "user@gmail.com",
                NormalizedUserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com",
                FirstName = "Test",
                LastName = "User"
            };

            User1.PasswordHash =
                 hasher.HashPassword(User1, "password123");

            User2 = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@gmail.com",
                NormalizedUserName = "guest@gmail.com",
                Email = "guest@gmail.com",
                NormalizedEmail = "guest@gmail.com",
                FirstName = "Test",
                LastName = "Guest",
                ProfilePicture = "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png"
            };

            User2.PasswordHash =
            hasher.HashPassword(User2, "password321");

            Admin = new ApplicationUser()
            {
                Id = "8acdd283-300d-4ef1-a83f-813efc164767",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                ProfilePicture = "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png"
            };

            Admin.PasswordHash =
            hasher.HashPassword(Admin, "adminpassword213");
        }

        private void SeedCategories() 
        {
            FirstCategory = new Category()
            {
                Id = 1,
                Name = "Appetizer"
            };

            SecondCategory = new Category()
            {
                Id = 2,
                Name = "Main Course"
            };

            ThirdCategory = new Category()
            {
                Id = 3,
                Name = "Dessert"
            };
        }

        private void SeedDifficulties() 
        {
            Beginner = new Difficulty()
            {
                Id = 1,
                Name = "Beginner",
                Description = "Recipes suitable for novice cooks with basic cooking skills.",
                SkillLevel = 1,
                IngredientComplexity = "Common ingredients."
            };

            Intermediate = new Difficulty()
            {
                Id = 2,
                Name = "Intermediate",
                Description = "Recipes requiring some cooking experience and familiarity with various cooking techniques.",
                SkillLevel = 3,
                IngredientComplexity = "Mix of common and some specialty ingredients."
            };

            Advanced = new Difficulty()
            {
                Id = 3,
                Name = "Advanced",
                Description = "Recipes suitable for experienced cooks with confidence in their cooking skills.",
                SkillLevel = 5,
                IngredientComplexity = "Primarily specialty ingredients."
            };

            Expert = new Difficulty()
            {
                Id = 4,
                Name = "Expert",
                Description = "Highly challenging recipes requiring expert-level cooking skills and experience.",
                SkillLevel = 7,
                IngredientComplexity = "Rare or exotic ingredients."
            };

            MasterChef = new Difficulty()
            {
                Id = 5,
                Name = "Master Chef",
                Description = "Culinary creations for professionals or exceptionally skilled home cooks.",
                SkillLevel = 9,
                IngredientComplexity = "Varied, may include rare, seasonal, or hard-to-find ingredients."
            };
        }

        private void SeedRecipes()
        {
            Moussaka = new Recipe()
            {
                Id = 1,
                Name = "Moussaka",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n",
                ImageUrl = "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459",
                PreparationTime = 60,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = Intermediate.Id,
                CookId = User1.Id
            };

            Pancakes = new Recipe()
            {
                Id = 2,
                Name = "Homemade Pancakes",
                Instructions = "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512",
                PreparationTime = 35,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = Beginner.Id,
                CookId = User1.Id
            };
        }
        private void SeedComments()
        {
            MoussakaComment = new Comment()
            {
                Id = 1,
                Title = "Very good Moussaka!",
                Description = "I made this moussaka with your recipe and its awesome.",
                AuthorId = User2.Id,
                PostedOn = DateTime.Now,
                RecipeId = 1               
            };
        }
        private void SeedIngredient()
        {
            //Moussaka Ingredients
            MoussakaPotato = new Ingredient()
            {
                Id = 1,
                Name = "potato",
                Quantity = 4,
                Unit = "kg",
                RecipeId = 1
            };
            MoussakaМeat = new Ingredient()
            {
                Id = 2,
                Name = "minced meat",
                Quantity = 3,
                Unit = "kg",
                RecipeId = 1
            };

            //Pancakes Ingredients
            PancakesFlour = new Ingredient()
            {
                Id = 3,
                Name = "flour",
                Quantity = 1.5M,
                Unit = "cups",
                RecipeId = 2
            };
            PancakesMilk = new Ingredient()
            {
                Id = 4,
                Name = "milk",
                Quantity = 1.75M,
                Unit = "cups",
                RecipeId = 2
            };
            PancakesEgg = new Ingredient()
            {
                Id = 5,
                Name = "egg",
                Unit = "count",
                Quantity = 1,
                RecipeId = 2
            };
            PancakesButter = new Ingredient()
            {
                Id = 6,
                Name = "melted butter",
                Unit = "cup",
                Quantity = 1,
                RecipeId = 2
            };
            PancakesSugar = new Ingredient()
            {
                Id = 7,
                Name = "white sugar",
                Unit = "tablespoon",
                Quantity = 1,
                RecipeId = 2
            };
            PancakesBakingPowder = new Ingredient()
            {
                Id = 8,
                Name = "baking powder",
                Quantity = 2,
                Unit = "tablespoons",
                RecipeId = 2
            };
            PancakesSalt = new Ingredient()
            {
                Id = 9,
                Name = "salt",
                Quantity = 1,
                Unit = "tablespoon",
                RecipeId = 2
            };
        }
    }
}
