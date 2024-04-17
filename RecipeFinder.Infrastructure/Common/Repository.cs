using Microsoft.EntityFrameworkCore;
using RecipeFinder.Data;

namespace RecipeFinder.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(RecipeFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }
    }
}
