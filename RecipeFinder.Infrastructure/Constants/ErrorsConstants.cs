using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Constants
{
    public static class ErrorsConstants
    {
        public const string RequiredErrorMessage = "The \"{0}\" field is required.";
        public const string LengthErrorMessage = "The \"{0}\" field needs to be between {2} and {1} symbols.";
        public const string PrepTimeLengthErrorMessage = "The \"{0}\" field needs to be between {1} and {2} minutes.";
        public const string QuantityLengthErrorMessage = "The \"{0}\" field needs to be between {1} and {2}.";
    }
}
