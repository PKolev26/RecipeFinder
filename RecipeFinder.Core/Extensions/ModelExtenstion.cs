using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Core.Contracts.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Extensions
{
    public static class ModelExtenstion
    {
        public static string GetName(this IRecipeModel recipeName)
        {
            string info = recipeName.Name;
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
