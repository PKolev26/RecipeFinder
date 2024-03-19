using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Services.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;

        public RecipeService(IRepository repository)
        {
            this.repository = repository;
        }


    }
}
