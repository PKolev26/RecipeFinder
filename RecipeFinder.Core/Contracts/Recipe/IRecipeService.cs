using RecipeFinder.Core.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<AllRecipeViewModel>> AllRecipesAsync();
    }
}
