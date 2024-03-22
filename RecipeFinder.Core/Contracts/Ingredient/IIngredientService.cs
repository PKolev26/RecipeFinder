using RecipeFinder.Core.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Ingredient
{
    public interface IIngredientService
    {
        Task<int> AddAsync(IngredientsAddViewModel model, int id);
    }
}
