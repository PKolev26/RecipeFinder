using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Constants
{
    public static class ErrorsConstants
    {
        public const string RequiredErrorMessage = "This {0} field is required.";
        public const string LengthErrorMessage = "This {0} field needs to be between {2} and {1} symbols.";
    }
}
