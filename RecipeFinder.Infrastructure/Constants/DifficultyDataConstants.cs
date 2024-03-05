using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Constants
{
    public static class DifficultyDataConstants
    {

        // Difficulty Name Data Constants
        public const int DifficultyNameMaxLength = 30;
        public const int DifficultyNameMinLength = 2;

        // Difficulty Description Data Constants
        public const int DifficultyDescriptionMaxLength = 50;
        public const int DifficultyDescriptionMinLength = 5;

        // Diffuculty SkillLevel Data Constants
        public const double DifficultySkillLevelMin = 0.01;
        public const double DifficultySkillLevelMax = 10.00;

        // Difficulty IngredientComplexity Data Constants
        public const int DifficultyIngredientComplexityMaxLength = 50;
        public const int DifficultyIngredientComplexityMinLength = 5;
    }
}
