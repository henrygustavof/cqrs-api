namespace Project.API.Constants
{
    public static class HttErrorResponseConstants
    {
        public const string Status400BadRequest = "Bad Request";
        public const string Status401Unauthorized = "You are Unauthorized";
        public const string Status403Forbidden = "Forbidden";
        public const string Status404NotFound = "Resource not found";
        public const string Status415UnsupportedMediaType = "Unsupported media type";
        public const string Status500InternalServerError = "An unknown error has occurred, please try later";
        public const string StatusDefaultError = "An unknown error has occurred";
    }
}
