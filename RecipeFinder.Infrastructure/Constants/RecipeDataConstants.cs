namespace RecipeFinder.Infrastructure.Constants
{
    public static class RecipeDataConstants
    {
        // Recipe Name Data Constants
        public const int RecipeNameMaxLength = 50;
        public const int RecipeNameMinLength = 5;

        // Recipe Instructions Data Constants
        public const int RecipeInstructionsMaxLength = 500;
        public const int RecipeInstructionsMinLength = 10;

        // Date and time format
        public const string DateAndTimeFormat = "dd/MM/yyyy HH:mm";

        // Recipe PreparationTime Data Constants
        public const int RecipePreparetionTimeMinLength = 1;
        public const int RecipePreparetionTimeMaxLength = 720;
    }
}
