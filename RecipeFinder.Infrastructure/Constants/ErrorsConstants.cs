namespace RecipeFinder.Infrastructure.Constants
{
    public static class ErrorsConstants
    {
        // Error Messages

        // Required Error Message
        public const string RequiredErrorMessage = "The \"{0}\" field is required.";

        // String Length Error Message
        public const string LengthErrorMessage = "The \"{0}\" field needs to be between {2} and {1} symbols.";

        // Preparation Time Error Messages
        public const string PrepTimeLengthErrorMessage = "The \"{0}\" field needs to be between {1} and {2} minutes.";

        // Quantity Length Error Messages
        public const string QuantityLengthErrorMessage = "The \"{0}\" field needs to be between {1} and {2}.";
    }
}
