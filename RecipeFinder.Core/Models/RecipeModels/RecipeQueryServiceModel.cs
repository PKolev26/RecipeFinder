    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Models.RecipeModels
{
    public class RecipeQueryServiceModel
    {
        public int TotalRecipesCount { get; set; }

        public IEnumerable<RecipeServiceModel> Recipes { get; set; } = new List<RecipeServiceModel>();
    }
}
