using Microsoft.EntityFrameworkCore;
using RecipeFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
