using RecipeFinder.ModelBinders;

namespace RecipeFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);
            
            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                /*app.UseDeveloperExceptionPage();*/   // Uncomment in Production
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); // Remove in Production
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
                app.UseExceptionHandler("/Home/Error/500");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}