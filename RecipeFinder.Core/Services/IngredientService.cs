using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository repository;

        public IngredientService(IRepository repository)
        {
            this.repository = repository;
        }

        // AddAsync method is used to add an ingredient to a recipe. It takes an IngredientsAddViewModel and recipeId as parameters. It creates a new Ingredient object and adds it to the database.
        public async Task AddAsync(IngredientsAddViewModel model, int id)
        {
            Ingredient newIngredient = new Ingredient
            {
                Name = model.Name,
                Quantity = model.Quantity,
                Unit = model.Unit,
                RecipeId = id
                
            };

            await repository.AddAsync(newIngredient);
            await repository.SaveChangesAsync();
        }
    }
}
