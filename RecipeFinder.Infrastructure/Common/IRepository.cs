using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllAsReadOnly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
