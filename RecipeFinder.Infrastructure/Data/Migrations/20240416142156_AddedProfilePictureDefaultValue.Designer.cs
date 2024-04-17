﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeFinder.Data;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    [DbContext(typeof(RecipeFinderDbContext))]
    [Migration("20240416142156_AddedProfilePictureDefaultValue")]
    partial class AddedProfilePictureDefaultValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("This Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("The Category Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Appetizer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Main Course"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dessert"
                        });
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Comment Author Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasComment("Comment Description");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Comment Posted Date");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasComment("Recipe Identifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Comment Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Description = "I made this moussaka with your recipe and its awesome.",
                            PostedOn = new DateTime(2024, 4, 16, 17, 21, 55, 564, DateTimeKind.Local).AddTicks(8615),
                            RecipeId = 1,
                            Title = "Very good Moussaka!"
                        });
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("This Difficulty Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The Difficulty Description");

                    b.Property<string>("IngredientComplexity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The Ingredient Complexity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("The Difficulty Name");

                    b.Property<decimal>("SkillLevel")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The recommended skill level that the cook should have");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Recipes suitable for novice cooks with basic cooking skills.",
                            IngredientComplexity = "Common ingredients.",
                            Name = "Beginner",
                            SkillLevel = 1m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Recipes requiring some cooking experience and familiarity with various cooking techniques.",
                            IngredientComplexity = "Mix of common and some specialty ingredients.",
                            Name = "Intermediate",
                            SkillLevel = 3m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Recipes suitable for experienced cooks with confidence in their cooking skills.",
                            IngredientComplexity = "Primarily specialty ingredients.",
                            Name = "Advanced",
                            SkillLevel = 5m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Highly challenging recipes requiring expert-level cooking skills and experience.",
                            IngredientComplexity = "Rare or exotic ingredients.",
                            Name = "Expert",
                            SkillLevel = 7m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Culinary creations for professionals or exceptionally skilled home cooks.",
                            IngredientComplexity = "Varied, may include rare, seasonal, or hard-to-find ingredients.",
                            Name = "Master Chef",
                            SkillLevel = 9m
                        });
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The Ingredient Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The Ingredient Name");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The Ingredient Quantity");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasComment("Recipe Identifier");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("The unit in which the ingredient is measured");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "potato",
                            Quantity = 4m,
                            RecipeId = 1,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "minced meat",
                            Quantity = 3m,
                            RecipeId = 1,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 7,
                            Name = "white sugar",
                            Quantity = 1m,
                            RecipeId = 2,
                            Unit = "tablespoon"
                        },
                        new
                        {
                            Id = 9,
                            Name = "salt",
                            Quantity = 1m,
                            RecipeId = 2,
                            Unit = "tablespoon"
                        },
                        new
                        {
                            Id = 4,
                            Name = "milk",
                            Quantity = 1.75m,
                            RecipeId = 2,
                            Unit = "cups"
                        },
                        new
                        {
                            Id = 3,
                            Name = "flour",
                            Quantity = 1.5m,
                            RecipeId = 2,
                            Unit = "cups"
                        },
                        new
                        {
                            Id = 5,
                            Name = "egg",
                            Quantity = 1m,
                            RecipeId = 2,
                            Unit = "count"
                        },
                        new
                        {
                            Id = 6,
                            Name = "melted butter",
                            Quantity = 1m,
                            RecipeId = 2,
                            Unit = "cup"
                        },
                        new
                        {
                            Id = 8,
                            Name = "baking powder",
                            Quantity = 2m,
                            RecipeId = 2,
                            Unit = "tablespoons"
                        });
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The Recipe Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("The Recipe Category Id");

                    b.Property<string>("CookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The Cook Identifier");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int")
                        .HasComment("The Recipe Difficulty Id");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The Recipe Cover Image");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("The Recipe Instructions");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("The Recipe Name");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of post");

                    b.Property<int>("PreparationTime")
                        .HasColumnType("int")
                        .HasComment("The Recipe Preparation Time");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CookId");

                    b.HasIndex("DifficultyId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            CookId = "dea12856-c198-4129-b3f3-b893d8395082",
                            DifficultyId = 2,
                            ImageUrl = "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459",
                            Instructions = "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n",
                            Name = "Moussaka",
                            PostedOn = new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(111),
                            PreparationTime = 60
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CookId = "dea12856-c198-4129-b3f3-b893d8395082",
                            DifficultyId = 1,
                            ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512",
                            Instructions = "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.",
                            Name = "Homemade Pancakes",
                            PostedOn = new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(117),
                            PreparationTime = 35
                        });
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.RecipeUser", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasComment("Recipe Identifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Maker Identifier");

                    b.HasKey("RecipeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipesUsers");
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a98167b1-abab-4d99-b410-772bc4392c89",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEONIB6blVvMsmzOdqS1OmxU5J/A33D4iuyxDY62Tak9Bxk7mkfWeJsW+J4afKN4NGw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "66f39047-2dd6-4e66-84fb-7ca54c10fc37",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com",
                            FirstName = "Test",
                            LastName = "User",
                            ProfilePicture = ""
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c0681ae3-37aa-4692-9e2b-9c363176c638",
                            Email = "guest@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@gmail.com",
                            NormalizedUserName = "guest@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECHmkUhG7s9Tap0gJwd2JDcngMHfL7jOXFbEOVLqHL+lUIVokewNW0BfS+BEZwJobA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bd167cdb-277d-47d0-a71d-eb30d6eb2ad0",
                            TwoFactorEnabled = false,
                            UserName = "guest@gmail.com",
                            FirstName = "Test",
                            LastName = "Guest",
                            ProfilePicture = "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png"
                        },
                        new
                        {
                            Id = "8acdd283-300d-4ef1-a83f-813efc164767",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cc6faa78-984f-41a1-b330-33fdf1738f2c",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPDDN6uhgWGD2+1HMckAdOhAkumjijMOtrfh3rRihKlK0fIXA20Vys7ffidWrHYHaQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7cd18bdf-9108-4115-8f13-811ea0a2a2ba",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            ProfilePicture = "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Recipe", b =>
                {
                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.ApplicationUser", "Cook")
                        .WithMany()
                        .HasForeignKey("CookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Cook");

                    b.Navigation("Difficulty");
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.RecipeUser", b =>
                {
                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.Recipe", "Recipe")
                        .WithMany("RecipesUsers")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RecipeFinder.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeFinder.Infrastructure.Data.Models.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ingredients");

                    b.Navigation("RecipesUsers");
                });
#pragma warning restore 612, 618
        }
    }
}