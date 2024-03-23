using Microsoft.EntityFrameworkCore;
using RecipeFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
    }
}
