using RecipeFinder.Core.Contracts.Recipe;
using System.Text.RegularExpressions;

namespace RecipeFinder.Core.Extensions
{
    public static class ModelExtenstion
    {
        // This method is used to get the name of the recipe and remove any special characters. Used for URLs.
        public static string GetName(this IRecipeModel recipeName)
        {
            string info = recipeName.Name;
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
