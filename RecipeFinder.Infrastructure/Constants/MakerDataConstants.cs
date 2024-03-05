using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Constants
{
    public static class MakerDataConstants
    {

        // Maker FirstName Data Constants
        public const int MakerFirstNameMaxLength = 30;
        public const int MakerFirstNameMinLength = 3;

        // Maker LastName Data Constants
        public const int MakerLastNameMaxLength = 30;
        public const int MakerLastNameMinLength = 3;

        // Maker SkillLevel Data Constants
        public const double MakerSkillLevelMin = 0.01;
        public const double MakerSkillLevelMax = 10.00;
    }
}
