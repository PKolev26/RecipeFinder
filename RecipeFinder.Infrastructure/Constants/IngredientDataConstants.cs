using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Constants
{
    public static class IngredientDataConstants
    {
        // Ingredient Name Data Constants
        public const int IngredientNameMaxLength = 50;
        public const int IngredientNameMinLength = 3;

        // Ingredient Quantity Data Constants
        public const double IngredientQuantityMaxLength = 0.01;
        public const double IngredientQuantityMinLength = 999.99;

        // Ingredient Unit Data Constants
        public const int IngredientUnitMaxLength = 10;
        public const int IngredientUnitMinLength = 1;

    }
}
