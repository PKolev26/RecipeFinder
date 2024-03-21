using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository repository;

        public IngredientService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddAsync(IngredientsAddViewModel model, int recipeId)
        {
            var newIngredient = new IngredientsAddViewModel
            {

                Name = model.Name,
                Quantity = model.Quantity,
                Unit = model.Unit,
                RecipeId = recipeId
                
            };

            await repository.AddAsync(newIngredient);
            await repository.SaveChangesAsync();

            return newIngredient.Id;
        }
    }
}
