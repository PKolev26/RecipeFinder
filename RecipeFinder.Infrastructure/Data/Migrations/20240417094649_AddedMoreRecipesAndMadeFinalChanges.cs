using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddedMoreRecipesAndMadeFinalChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95a2a15-12cc-4567-9cfb-eeaa67294b07", "AQAAAAEAACcQAAAAEF/ATRWMCVXYuXoI6jeKvG8p+fxwsswjnonIF0QTHcbYB1cwEERjdTc3aFty7qX2MA==", "1c6dc899-c0a3-44f8-934e-6790d27de1a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f44e95e-21b7-43aa-a0db-6a3e60a2073d", "AQAAAAEAACcQAAAAENnTs+RB+TQx6rULyVHvqsPoOsejParYdwhEKSK7Hoih+YAJfss99w6RhO49OZrLNQ==", "60fc04fe-0926-4f24-bff4-e3b762b68ccb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96b3fbf0-484b-4bfb-9e5e-79c94246503f", "AQAAAAEAACcQAAAAEMlbXyvAuCWqGNMN53YePmCKpNut+HEKmuwPdlBZ3q/hWeUyjdus+nUasLjo9Vzsew==", "b136088e-3762-4765-82c8-b8bdb5a1c8f4" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookId", "DifficultyId", "ImageUrl", "Instructions", "Name", "PostedOn", "PreparationTime" },
                values: new object[,]
                {
                    { 3, 2, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459", "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n", "Moussaka", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1767), 60 },
                    { 4, 3, "dea12856-c198-4129-b3f3-b893d8395082", 1, "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512", "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.", "Homemade Pancakes", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1808), 35 },
                    { 5, 2, "dea12856-c198-4129-b3f3-b893d8395082", 4, "https://www.allrecipes.com/thmb/Z4Mdrd87chexT64ykV5o1cK0ZKM=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/231939_Honey-Glazed-Chicken_Adam-Vaccarezza_4564886_original-4x3-1-acb1de801b6541b69e06bf7b731c1b60.jpg", "1. Preheat oven to 180°C.\r\n2. Season chicken with salt & pepper.\r\n3. Heat oil in a skillet. Brown chicken on both sides.\r\n4. Mix honey, soy sauce, garlic, & ginger. Pour over chicken.\r\n5. Bake for 30 minutes.\r\n6. Baste chicken with sauce. Bake for another 15 minutes.\r\n7. Serve with rice or vegetables. Enjoy!\r\n", "Honey Glazed Chicken", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1813), 20 },
                    { 6, 1, "dea12856-c198-4129-b3f3-b893d8395082", 1, "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F03%2F19%2F238691-Simple-Macaroni-And-Cheese-mfs_006.jpg&q=60&c=sc&poi=auto&orient=true&h=512", "1. Preheat oven to 180°C.\r\n2. Cook macaroni according to package instructions.\r\n3. Melt butter in a saucepan. Stir in flour, salt, pepper, & mustard.\r\n4. Add milk. Cook & stir until thickened.\r\n5. Add cheese. Stir until melted.\r\n6. Combine macaroni & cheese sauce.\r\n7. Pour into a baking dish. Top with breadcrumbs.\r\n8. Bake for 30 minutes. Enjoy!\r\n", "Macaroni and Cheese", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1817), 15 },
                    { 7, 3, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://www.allrecipes.com/thmb/dys0tqgU7Sow1d_DS_S9Jf6NeAI=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/AllRecipes_Grandmothers_Cheesecake_0003-2000-06db8cb260484b81aa1dbd0d904603a1.jpg", "1. Preheat oven to 180°C.\r\n2. Mix graham cracker crumbs, sugar, & butter. Press into a pan.\r\n3. Beat cream cheese, sugar, & vanilla until smooth.\r\n4. Add eggs one at a time. Beat well.\r\n5. Pour over crust. Bake for 1 hour.\r\n6. Cool. Chill for 4 hours. Enjoy!\r\n", "Classic Cheesecake", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1821), 15 },
                    { 8, 3, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://www.allrecipes.com/thmb/BVIa5dKfGQlpQJ_epc6wH6Vm990=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/IMG_8145_Chocolate-Mousse-for-Beginners-4x3-cropped-757ae43035ff48cc8bc9ccffbd6cf3b7.jpg", "1. Melt chocolate & butter. Cool.\r\n2. Beat egg yolks & sugar. Add chocolate mixture.\r\n3. Beat egg whites & sugar until stiff peaks form.\r\n4. Fold into chocolate mixture.\r\n5. Pour into cups. Chill for 4 hours. Enjoy!\r\n", "Chocolate Mousse", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1825), 15 },
                    { 9, 3, "dea12856-c198-4129-b3f3-b893d8395082", 1, "https://www.allrecipes.com/thmb/iyfZNNm7WSl-1HVUzWjF9SpRST8=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8551641-CopycatCosmicBrownie_DDMFS-248-4x3-566596741ece4186b38d600960c75502.jpg", "1. Preheat oven to 180°C.\r\n2. Melt butter & chocolate. Cool.\r\n3. Beat eggs, sugar, & vanilla. Add chocolate mixture.\r\n4. Mix in flour, salt, & baking powder.\r\n5. Pour into a pan. Bake for 30 minutes.\r\n6. Cool. Cut into squares. Enjoy!\r\n", "Brownies", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1829), 15 },
                    { 10, 1, "dea12856-c198-4129-b3f3-b893d8395082", 4, "https://www.allrecipes.com/thmb/4oKhDBSBYC3abBYCbYB-IhGOWt4=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/4521556_Guacamole4x3photobybd.weld-c81ae0bd3f2b4893a8e309365dda023b.jpg", "1. Mash avocados in a bowl.\r\n2. Stir in onion, garlic, tomato, lime juice, salt, & pepper.\r\n3. Chill for 30 minutes. Enjoy!\r\n", "Guacamole", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1833), 25 },
                    { 11, 2, "dea12856-c198-4129-b3f3-b893d8395082", 3, "https://www.allrecipes.com/thmb/IsH0QXPRWAr8fCiwgmPxoL2SovE=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8623032_Cornbread-Taco-Bake_TheDailyGourmet_4x3-dc4b1ba794194b4f88eb9de04db33fd7.jpg", "1. Preheat oven to 180°C.\r\n2. Cook beef, onion, & garlic. Drain.\r\n3. Stir in beans, tomatoes, corn, & taco seasoning.\r\n4. Mix cornbread. Pour over beef mixture.\r\n5. Bake for 20 minutes.\r\n6. Top with cheese. Bake for another 10 minutes.\r\n7. Serve with sour cream & salsa. Enjoy!\r\n", "Cornbread Taco Bake", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1837), 30 },
                    { 12, 3, "dea12856-c198-4129-b3f3-b893d8395082", 5, "https://www.allrecipes.com/thmb/L8M8tLuZhT5iZshsHoLh6KTwuC8=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/9224625_EasyVanillaCake4x3-bf9a73c9f6024e9286d96e8f0b59d35d.jpg", "1. Preheat oven to 180°C.\r\n2. Mix flour, baking powder, & salt.\r\n3. Beat butter & sugar. Add eggs & vanilla.\r\n4. Add flour mixture & milk. Mix well.\r\n5. Pour into pans. Bake for 30 minutes.\r\n6. Cool. Frost with buttercream. Enjoy!\r\n", "Vanilla Cake", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1841), 30 },
                    { 13, 1, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://www.allrecipes.com/thmb/qQ6I8RE2ywUQqLKn9Kwz3TODXKo=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8426520_Buffalo-Wing-Pretzels_Nicole-Russell_4x3-bb2e8f6880cc4415bd724088f946a871.jpg", "1. Mix warm water, yeast, sugar, & salt. Add flour. Knead.\r\n2. Let dough rise for 1 hour.\r\n3. Divide dough into pieces. Roll into ropes. Shape into pretzels.\r\n4. Dip in baking soda water. Bake at 230°C (450°F) for 10 minutes.\r\n5. Brush with melted butter. Enjoy!\r\n", "Pretzels", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1844), 15 },
                    { 14, 2, "dea12856-c198-4129-b3f3-b893d8395082", 5, "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F05%2F30%2F236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512", "1. Preheat grill to high heat.\r\n2. Season beef with salt, pepper, & garlic powder.\r\n3. Grill beef for 5 minutes per side.\r\n4. Reduce heat. Grill for 20 minutes.\r\n5. Let beef rest for 10 minutes. Slice & serve. Enjoy!\r\n", "Grilled Tri-Tip Beef", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1949), 60 },
                    { 15, 2, "dea12856-c198-4129-b3f3-b893d8395082", 5, "https://www.allrecipes.com/thmb/ywnMvmkYn5obresV_z3-oSW_wac=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/8611251_Fish-Puttanesca_Brenda-Venable_4x3-b51d77e6c84440609a3c8faf183dc8d2.jpg", "1. Preheat oven to 180°C.\r\n2. Season fish with salt & pepper.\r\n3. Heat oil in a skillet. Brown fish on both sides.\r\n4. Add garlic, anchovies, capers, olives, & tomatoes. Simmer.\r\n5. Bake for 20 minutes.\r\n6. Serve with pasta or bread. Enjoy!\r\n", "Fish Puttanesca", new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1955), 30 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "PostedOn", "RecipeId", "Title" },
                values: new object[] { "I made this with your recipe and its awesome.", new DateTime(2024, 4, 17, 12, 46, 48, 513, DateTimeKind.Local).AddTicks(8737), 9, "Very good brownies" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 10, "chicken thighs", 4m, 5, "pieces" },
                    { 11, "macaroni", 1m, 6, "cup" },
                    { 12, "cheddar cheese", 2m, 6, "cups" },
                    { 13, "cream cheese", 2m, 7, "cups" },
                    { 14, "dark chocolate", 200m, 8, "grams" },
                    { 15, "dark chocolate", 200m, 9, "grams" },
                    { 16, "avocado", 2m, 10, "pieces" },
                    { 17, "all-purpose flour", 3m, 13, "cups" },
                    { 18, "cornbread mix", 1m, 11, "package" },
                    { 19, "tri-tip beef", 1m, 14, "pound" },
                    { 20, "white fish fillets", 4m, 15, "pieces" },
                    { 21, "all-purpose flour", 2m, 12, "cups" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0681ae3-37aa-4692-9e2b-9c363176c638", "AQAAAAEAACcQAAAAECHmkUhG7s9Tap0gJwd2JDcngMHfL7jOXFbEOVLqHL+lUIVokewNW0BfS+BEZwJobA==", "bd167cdb-277d-47d0-a71d-eb30d6eb2ad0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc6faa78-984f-41a1-b330-33fdf1738f2c", "AQAAAAEAACcQAAAAEPDDN6uhgWGD2+1HMckAdOhAkumjijMOtrfh3rRihKlK0fIXA20Vys7ffidWrHYHaQ==", "7cd18bdf-9108-4115-8f13-811ea0a2a2ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a98167b1-abab-4d99-b410-772bc4392c89", "AQAAAAEAACcQAAAAEONIB6blVvMsmzOdqS1OmxU5J/A33D4iuyxDY62Tak9Bxk7mkfWeJsW+J4afKN4NGw==", "66f39047-2dd6-4e66-84fb-7ca54c10fc37" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookId", "DifficultyId", "ImageUrl", "Instructions", "Name", "PostedOn", "PreparationTime" },
                values: new object[,]
                {
                    { 1, 2, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459", "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n", "Moussaka", new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(111), 60 },
                    { 2, 3, "dea12856-c198-4129-b3f3-b893d8395082", 1, "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512", "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.", "Homemade Pancakes", new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(117), 35 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "PostedOn", "RecipeId", "Title" },
                values: new object[] { "I made this moussaka with your recipe and its awesome.", new DateTime(2024, 4, 16, 17, 21, 55, 564, DateTimeKind.Local).AddTicks(8615), 1, "Very good Moussaka!" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 1, "potato", 4m, 1, "kg" },
                    { 2, "minced meat", 3m, 1, "kg" },
                    { 3, "flour", 1.5m, 2, "cups" },
                    { 4, "milk", 1.75m, 2, "cups" },
                    { 5, "egg", 1m, 2, "count" },
                    { 6, "melted butter", 1m, 2, "cup" },
                    { 7, "white sugar", 1m, 2, "tablespoon" },
                    { 8, "baking powder", 2m, 2, "tablespoons" },
                    { 9, "salt", 1m, 2, "tablespoon" }
                });
        }
    }
}
