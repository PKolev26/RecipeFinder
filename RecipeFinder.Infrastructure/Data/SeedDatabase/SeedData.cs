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
        public IdentityUser User1 { get; set; }
        public IdentityUser User2 { get; set; }

        public Category FirstCategory { get; set; }
        public Category SecondCategory { get; set; }
        public Category ThirdCategory { get; set; }

        public Difficulty Beginner { get; set; }
        public Difficulty Intermediate { get; set; }
        public Difficulty Advanced { get; set; }
        public Difficulty Expert { get; set; }
        public Difficulty MasterChef { get; set; }

        public Recipe Musaka {  get; set; }

        public Comment MusakaComment { get; set; }

        public Ingredient MusakaPotato { get; set; }

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
            var hasher = new PasswordHasher<IdentityUser>();

            User1 = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "user@gmail.com",
                NormalizedUserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com"
            };

            User1.PasswordHash =
                 hasher.HashPassword(User1, "password123");

            User2 = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@gmail.com",
                NormalizedUserName = "guest@gmail.com",
                Email = "guest@gmail.com",
                NormalizedEmail = "guest@gmail.com"
            };

            User2.PasswordHash =
            hasher.HashPassword(User2, "password321");
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
            Musaka = new Recipe()
            {
                Id = 1,
                Name = "Musaka",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n",
                ImageUrl = "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459",
                PreparationTime = 60,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = Intermediate.Id,
                CookId = User1.Id
            };
        }
        private void SeedComments()
        {
            MusakaComment = new Comment()
            {
                Id = 1,
                Title = "Very good Musaka!",
                Description = "I made this musaka with your recipe and its awesome.",
                AuthorId = User2.Id,
                PostedOn = DateTime.Now,
                RecipeId = 1               
            };
        }
        private void SeedIngredient()
        {
            MusakaPotato = new Ingredient()
            {
                Id = 1,
                Name = "Potato",
                Quantity = 4,
                Unit = "kg",
                RecipeId = 1
            };
        }
    }
}
