using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Admin;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using Repository = RecipeFinder.Infrastructure.Common.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>(); 
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSignalR();
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<RecipeFinderDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RecipeFinderDbContext>();

            return services;
        }
    }
}
