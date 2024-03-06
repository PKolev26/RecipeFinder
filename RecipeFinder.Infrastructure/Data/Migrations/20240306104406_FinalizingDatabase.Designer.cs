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
    [Migration("20240306104406_FinalizingDatabase")]
    partial class FinalizingDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
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

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b061f59c-e4f3-422b-8ae1-34ed66061a8b",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEL0D8C+xgOUJMI44BEneTpHL5xGdry8u7wJzd4lhFbIMEEbiv11px4IMK51A0H6Omw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3e0a5a7f-4266-491d-9801-e6b0165cd4cc",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "55b3ed9e-d896-45fb-8527-d126cf4e2863",
                            Email = "guest@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@gmail.com",
                            NormalizedUserName = "guest@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEEsmRmCRzlQ9+1EgRpQLclTwraE1bBX3ccZ3QMURxf8A2oSeDCaT+JiKM6jG6tjVgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6fddc879-1bc8-4044-860c-e2159a1ea24c",
                            TwoFactorEnabled = false,
                            UserName = "guest@gmail.com"
                        });
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
                            Description = "I made this musaka with your recipe and its awesome.",
                            PostedOn = new DateTime(2024, 3, 6, 12, 44, 5, 938, DateTimeKind.Local).AddTicks(2969),
                            RecipeId = 1,
                            Title = "Very good Musaka!"
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

                    b.Property<double>("SkillLevel")
                        .HasColumnType("float")
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
                            SkillLevel = 1.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Recipes requiring some cooking experience and familiarity with various cooking techniques.",
                            IngredientComplexity = "Mix of common and some specialty ingredients.",
                            Name = "Intermediate",
                            SkillLevel = 3.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Recipes suitable for experienced cooks with confidence in their cooking skills.",
                            IngredientComplexity = "Primarily specialty ingredients.",
                            Name = "Advanced",
                            SkillLevel = 5.0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Highly challenging recipes requiring expert-level cooking skills and experience.",
                            IngredientComplexity = "Rare or exotic ingredients.",
                            Name = "Expert",
                            SkillLevel = 7.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Culinary creations for professionals or exceptionally skilled home cooks.",
                            IngredientComplexity = "Varied, may include rare, seasonal, or hard-to-find ingredients.",
                            Name = "Master Chef",
                            SkillLevel = 9.0
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

                    b.Property<double>("Quantity")
                        .HasColumnType("float")
                        .HasComment("The Ingredient Quantity");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasComment("Recipe Identifier");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("The unit in which the ingredient is measured");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Potato",
                            Quantity = 4.0,
                            RecipeId = 1,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Minced Meat",
                            Quantity = 3.0,
                            RecipeId = 1,
                            Unit = "kg"
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
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
                            Name = "Musaka",
                            PostedOn = new DateTime(2024, 3, 6, 12, 44, 5, 984, DateTimeKind.Local).AddTicks(3676),
                            PreparationTime = 60
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Cook")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
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
