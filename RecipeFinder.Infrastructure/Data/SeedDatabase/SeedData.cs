using Microsoft.AspNetCore.Identity;
using RecipeFinder.Infrastructure.Data.Models;

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
        public Recipe HoneyGlazedChicken { get; set; }
        public Recipe MacaroniAndCheese { get; set; }
        public Recipe Cheesecake { get; set; }
        public Recipe ChocolateMousse { get; set; }
        public Recipe Brownies { get; set; }
        public Recipe Guacamole { get; set; }
        public Recipe Pretzels { get; set; }
        public Recipe CornbreadTacoBake { get; set; }
        public Recipe GrilledTriTipBeef { get; set; }
        public Recipe FishPuttanesca { get; set; }
        public Recipe VanillaCake { get; set; }

        // Comment
        public Comment BrowniesComment { get; set; }

        // Ingredient
        public Ingredient HoneyGlazedChickenChicken { get; set; }
        public Ingredient MakaroniAndCheeseMakaroni { get; set; }
        public Ingredient MakaroniAndCheeseCheese { get; set; }

        public Ingredient CheesecakeCreamCheese { get; set; }

        public Ingredient ChocolateMousseChocolate { get; set; }

        public Ingredient BrowniesChocolate { get; set; }

        public Ingredient GuacamoleAvocado { get; set; }

        public Ingredient PretzelsFlour { get; set; }

        public Ingredient CornbreadTacoBakeCornbread { get; set; }

        public Ingredient GrilledTriTipBeefBeef { get; set; }

        public Ingredient FishPuttanescaFish { get; set; }

        public Ingredient VanillaCakeFlour { get; set; }


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
                Id = 3,
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
                Id = 4,
                Name = "Homemade Pancakes",
                Instructions = "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512",
                PreparationTime = 35,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = Beginner.Id,
                CookId = User1.Id
            };

            HoneyGlazedChicken = new Recipe()
            {
                Id = 5,
                Name = "Honey Glazed Chicken",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Season chicken with salt & pepper.\r\n3. Heat oil in a skillet. Brown chicken on both sides.\r\n4. Mix honey, soy sauce, garlic, & ginger. Pour over chicken.\r\n5. Bake for 30 minutes.\r\n6. Baste chicken with sauce. Bake for another 15 minutes.\r\n7. Serve with rice or vegetables. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/Z4Mdrd87chexT64ykV5o1cK0ZKM=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/231939_Honey-Glazed-Chicken_Adam-Vaccarezza_4564886_original-4x3-1-acb1de801b6541b69e06bf7b731c1b60.jpg",
                PreparationTime = 20,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = Expert.Id,
                CookId = User1.Id
            };

            MacaroniAndCheese = new Recipe()
            {
                Id = 6,
                Name = "Macaroni and Cheese",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Cook macaroni according to package instructions.\r\n3. Melt butter in a saucepan. Stir in flour, salt, pepper, & mustard.\r\n4. Add milk. Cook & stir until thickened.\r\n5. Add cheese. Stir until melted.\r\n6. Combine macaroni & cheese sauce.\r\n7. Pour into a baking dish. Top with breadcrumbs.\r\n8. Bake for 30 minutes. Enjoy!\r\n",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F03%2F19%2F238691-Simple-Macaroni-And-Cheese-mfs_006.jpg&q=60&c=sc&poi=auto&orient=true&h=512",
                PreparationTime = 15,
                PostedOn = DateTime.Now,
                CategoryId = FirstCategory.Id,
                DifficultyId = Beginner.Id,
                CookId = User1.Id
            };

            Cheesecake = new Recipe()
            {
                Id = 7,
                Name = "Classic Cheesecake",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Mix graham cracker crumbs, sugar, & butter. Press into a pan.\r\n3. Beat cream cheese, sugar, & vanilla until smooth.\r\n4. Add eggs one at a time. Beat well.\r\n5. Pour over crust. Bake for 1 hour.\r\n6. Cool. Chill for 4 hours. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/dys0tqgU7Sow1d_DS_S9Jf6NeAI=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/AllRecipes_Grandmothers_Cheesecake_0003-2000-06db8cb260484b81aa1dbd0d904603a1.jpg",
                PreparationTime = 15,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = Intermediate.Id,
                CookId = User1.Id
            };

            ChocolateMousse = new Recipe()
            {
                Id = 8,
                Name = "Chocolate Mousse",
                Instructions = "1. Melt chocolate & butter. Cool.\r\n2. Beat egg yolks & sugar. Add chocolate mixture.\r\n3. Beat egg whites & sugar until stiff peaks form.\r\n4. Fold into chocolate mixture.\r\n5. Pour into cups. Chill for 4 hours. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/BVIa5dKfGQlpQJ_epc6wH6Vm990=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/IMG_8145_Chocolate-Mousse-for-Beginners-4x3-cropped-757ae43035ff48cc8bc9ccffbd6cf3b7.jpg",
                PreparationTime = 15,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = Intermediate.Id,
                CookId = User1.Id
            };

            Brownies = new Recipe()
            {
                Id = 9,
                Name = "Brownies",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Melt butter & chocolate. Cool.\r\n3. Beat eggs, sugar, & vanilla. Add chocolate mixture.\r\n4. Mix in flour, salt, & baking powder.\r\n5. Pour into a pan. Bake for 30 minutes.\r\n6. Cool. Cut into squares. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/iyfZNNm7WSl-1HVUzWjF9SpRST8=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8551641-CopycatCosmicBrownie_DDMFS-248-4x3-566596741ece4186b38d600960c75502.jpg",
                PreparationTime = 15,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = Beginner.Id,
                CookId = User1.Id
            };

            Guacamole = new Recipe()
            {
                Id = 10,
                Name = "Guacamole",
                Instructions = "1. Mash avocados in a bowl.\r\n2. Stir in onion, garlic, tomato, lime juice, salt, & pepper.\r\n3. Chill for 30 minutes. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/4oKhDBSBYC3abBYCbYB-IhGOWt4=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/4521556_Guacamole4x3photobybd.weld-c81ae0bd3f2b4893a8e309365dda023b.jpg",
                PreparationTime = 25,
                PostedOn = DateTime.Now,
                CategoryId = FirstCategory.Id,
                DifficultyId = Expert.Id,
                CookId = User1.Id
            };

            CornbreadTacoBake = new Recipe()
            {
                Id = 11,
                Name = "Cornbread Taco Bake",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Cook beef, onion, & garlic. Drain.\r\n3. Stir in beans, tomatoes, corn, & taco seasoning.\r\n4. Mix cornbread. Pour over beef mixture.\r\n5. Bake for 20 minutes.\r\n6. Top with cheese. Bake for another 10 minutes.\r\n7. Serve with sour cream & salsa. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/IsH0QXPRWAr8fCiwgmPxoL2SovE=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8623032_Cornbread-Taco-Bake_TheDailyGourmet_4x3-dc4b1ba794194b4f88eb9de04db33fd7.jpg",
                PreparationTime = 30,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = Advanced.Id,
                CookId = User1.Id
            };

            VanillaCake = new Recipe()
            {
                Id = 12,
                Name = "Vanilla Cake",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Mix flour, baking powder, & salt.\r\n3. Beat butter & sugar. Add eggs & vanilla.\r\n4. Add flour mixture & milk. Mix well.\r\n5. Pour into pans. Bake for 30 minutes.\r\n6. Cool. Frost with buttercream. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/L8M8tLuZhT5iZshsHoLh6KTwuC8=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/9224625_EasyVanillaCake4x3-bf9a73c9f6024e9286d96e8f0b59d35d.jpg",
                PreparationTime = 30,
                PostedOn = DateTime.Now,
                CategoryId = ThirdCategory.Id,
                DifficultyId = MasterChef.Id,
                CookId = User1.Id
            };

            Pretzels = new Recipe()
            {
                Id = 13,
                Name = "Pretzels",
                Instructions = "1. Mix warm water, yeast, sugar, & salt. Add flour. Knead.\r\n2. Let dough rise for 1 hour.\r\n3. Divide dough into pieces. Roll into ropes. Shape into pretzels.\r\n4. Dip in baking soda water. Bake at 230°C (450°F) for 10 minutes.\r\n5. Brush with melted butter. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/qQ6I8RE2ywUQqLKn9Kwz3TODXKo=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8426520_Buffalo-Wing-Pretzels_Nicole-Russell_4x3-bb2e8f6880cc4415bd724088f946a871.jpg",
                PreparationTime = 15,
                PostedOn = DateTime.Now,
                CategoryId = FirstCategory.Id,
                DifficultyId = Intermediate.Id,
                CookId = User1.Id
            };

            GrilledTriTipBeef = new Recipe()
            {
                Id = 14,
                Name = "Grilled Tri-Tip Beef",
                Instructions = "1. Preheat grill to high heat.\r\n2. Season beef with salt, pepper, & garlic powder.\r\n3. Grill beef for 5 minutes per side.\r\n4. Reduce heat. Grill for 20 minutes.\r\n5. Let beef rest for 10 minutes. Slice & serve. Enjoy!\r\n",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F05%2F30%2F236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512",
                PreparationTime = 60,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = MasterChef.Id,
                CookId = User1.Id
            };

            FishPuttanesca = new Recipe()
            {
                Id = 15,
                Name = "Fish Puttanesca",
                Instructions = "1. Preheat oven to 180°C.\r\n2. Season fish with salt & pepper.\r\n3. Heat oil in a skillet. Brown fish on both sides.\r\n4. Add garlic, anchovies, capers, olives, & tomatoes. Simmer.\r\n5. Bake for 20 minutes.\r\n6. Serve with pasta or bread. Enjoy!\r\n",
                ImageUrl = "https://www.allrecipes.com/thmb/ywnMvmkYn5obresV_z3-oSW_wac=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8611251_Fish-Puttanesca_Brenda-Venable_4x3-b51d77e6c84440609a3c8faf183dc8d2.jpg",
                PreparationTime = 30,
                PostedOn = DateTime.Now,
                CategoryId = SecondCategory.Id,
                DifficultyId = MasterChef.Id,
                CookId = User1.Id
            };
        }
        private void SeedComments()
        {
            BrowniesComment = new Comment()
            {
                Id = 1,
                Title = "Very good brownies",
                Description = "I made this with your recipe and its awesome.",
                AuthorId = User2.Id,
                PostedOn = DateTime.Now,
                RecipeId = Brownies.Id
            };
        }
        private void SeedIngredient()
        {
            HoneyGlazedChickenChicken = new Ingredient()
            {
                Id = 10,
                Name = "chicken thighs",
                Quantity = 4,
                Unit = "pieces",
                RecipeId = HoneyGlazedChicken.Id
            };

            MakaroniAndCheeseMakaroni = new Ingredient()
            {
                Id = 11,
                Name = "macaroni",
                Quantity = 1,
                Unit = "cup",
                RecipeId = MacaroniAndCheese.Id
            };

            MakaroniAndCheeseCheese = new Ingredient()
            {
                Id = 12,
                Name = "cheddar cheese",
                Quantity = 2,
                Unit = "cups",
                RecipeId = MacaroniAndCheese.Id
            };

            CheesecakeCreamCheese = new Ingredient()
            {
                Id = 13,
                Name = "cream cheese",
                Quantity = 2,
                Unit = "cups",
                RecipeId = Cheesecake.Id
            };

            ChocolateMousseChocolate = new Ingredient()
            {
                Id = 14,
                Name = "dark chocolate",
                Quantity = 200,
                Unit = "grams",
                RecipeId = ChocolateMousse.Id
            };

            BrowniesChocolate = new Ingredient()
            {
                Id = 15,
                Name = "dark chocolate",
                Quantity = 200,
                Unit = "grams",
                RecipeId = Brownies.Id
            };

            GuacamoleAvocado = new Ingredient()
            {
                Id = 16,
                Name = "avocado",
                Quantity = 2,
                Unit = "pieces",
                RecipeId = Guacamole.Id
            };

            PretzelsFlour = new Ingredient()
            {
                Id = 17,
                Name = "all-purpose flour",
                Quantity = 3,
                Unit = "cups",
                RecipeId = Pretzels.Id
            };

            CornbreadTacoBakeCornbread = new Ingredient()
            {
                Id = 18,
                Name = "cornbread mix",
                Quantity = 1,
                Unit = "package",
                RecipeId = CornbreadTacoBake.Id
            };

            GrilledTriTipBeefBeef = new Ingredient()
            {
                Id = 19,
                Name = "tri-tip beef",
                Quantity = 1,
                Unit = "pound",
                RecipeId = GrilledTriTipBeef.Id
            };

            FishPuttanescaFish = new Ingredient()
            {
                Id = 20,
                Name = "white fish fillets",
                Quantity = 4,
                Unit = "pieces",
                RecipeId = FishPuttanesca.Id
            };

            VanillaCakeFlour = new Ingredient()
            {
                Id = 21,
                Name = "all-purpose flour",
                Quantity = 2,
                Unit = "cups",
                RecipeId = VanillaCake.Id
            };
        }
    }
}
