using RecipeFinder.Core.Models.IngredientModels;

namespace RecipeFinder.Core.Contracts.Ingredient
{
    public interface IIngredientService
    {
        Task AddAsync(IngredientsAddViewModel model, int id);
    }
}
