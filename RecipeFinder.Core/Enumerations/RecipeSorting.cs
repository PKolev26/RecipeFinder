using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Enumerations
{
    public enum RecipeSorting
    {
        Newest = 0,
        Oldest = 1,
        Popular = 2,
        ByIngredientsCountAscending = 3,
        ByIngredientsCountDescending = 4,
        ByPreparationTimeAscending = 5,
        ByPreparationTimeDescending = 6,
    }
}
